using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Deporte
    {
        public Deporte()
        {
            Socios = new HashSet<Socio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Socio> Socios { get; set; }
    }
}
