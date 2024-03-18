namespace DomainLayer.Models
{
    public class Erros : BaseEntity
    {
        public string MetodoBase { get; set; }
        public string Mensaje { get; set; }
        public string StackTrace { get; set; }
        public string Usuario { get; set; }
        public string Tipo { get; set; }
    }
}
