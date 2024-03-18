namespace DomainLayer.Models
{
    public class ComprobanteFiscal : BaseEntity
    {
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
    }
}
