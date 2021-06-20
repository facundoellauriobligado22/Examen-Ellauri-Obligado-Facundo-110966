namespace Api.Models
{
    public partial class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int IdDeporte { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; }
    }
}
