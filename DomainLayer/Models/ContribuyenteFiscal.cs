using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models
{
    public class ContribuyenteFiscal : BaseEntity
    {
        [ForeignKey("TipoContribuyentes")]
        public int IdTipoContribuyente { get; set; }
        public string RncCedula { get; set; }
        public string Nombre { get; set; }
        public virtual TipoContribuyente? TipoContribuyentes { get; set; }
        public virtual List<ComprobanteFiscal> ComprobantesFiscales { get; set; }
    }
}
