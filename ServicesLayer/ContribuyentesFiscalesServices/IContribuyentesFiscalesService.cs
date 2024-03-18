using DomainLayer.Models;
using ServicesLayer.DTO;

namespace ServicesLayer.ContribuyentesFiscalesServices
{
    public interface IContribuyentesFiscalesService
    {
        Task<Response<ContribuyenteFiscal>> GetAllAsync();
        // Task<Response<ContribuyenteFiscal>> GetContribuyenteFiscalAsync(int id);
        Task<Response<string>> SetContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente);
        Task<Response<string>> UpdateContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente);
        // Task<Response<string>> DeleteContribuyenteFiscalAsync(int id);
    }
}
