using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Models
{
    public partial class parcialProg3SociosContext : DbContext
    {
        public parcialProg3SociosContext()
        {
        }

        public parcialProg3SociosContext(DbContextOptions<parcialProg3SociosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deportes { get; set; }
        public virtual DbSet<Socio> Socios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=prog3Modelo1; Password=11Prog32021; Server=138.99.7.66; Port=5432; Database=parcialProg3Socios; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.ToTable("deportes");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.ToTable("socios");

                entity.HasIndex(e => e.IdDeporte, "fki_fk_deporte");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellido).IsRequired();

                entity.Property(e => e.Calle).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Socios)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deporte");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
