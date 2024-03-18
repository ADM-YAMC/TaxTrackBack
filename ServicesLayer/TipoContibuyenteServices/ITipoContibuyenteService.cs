using DomainLayer.Models;
using ServicesLayer.DTO;

namespace ServicesLayer.TipoContibuyenteServices
{
    public interface ITipoContibuyenteService
    {
        Task<Response<TipoContribuyente>> GetAllAsync();
        // Task<Response<TipoContribuyente>> GetTipoContribuyenteAsync(int id);
        Task<Response<string>> SetTipoContribuyenteAsync(TipoContribuyente tipoContribuyente);
        Task<Response<string>> UpdateTipoContribuyenteAsync(TipoContribuyente tipoContribuyente);
        //Task<Response<string>> DeleteTipoContribuyenteAsync(int id);
    }
}
