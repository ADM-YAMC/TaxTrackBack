using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.DTO;
using ServicesLayer.ErrosServices;
using ServicesLayer.TipoContibuyenteServices;

namespace TaxTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContribuyenteController : ControllerBase
    {
        private readonly ITipoContibuyenteService _service;
        private readonly IErrosService _erros;
        public TipoContribuyenteController(ITipoContibuyenteService service, IErrosService erros)
        {
            _service = service;
            _erros = erros;
        }

        [HttpGet]
        public async Task<ActionResult<Response<TipoContribuyente>>> GetAll() =>
         await _service.GetAllAsync();

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Response<TipoContribuyente>>> Get(int id) =>
        //    await _service.GetTipoContribuyenteAsync(id);

        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddContribuyenteFiscalAsync(TipoContribuyente tipoContribuyente) =>
            await _service.SetTipoContribuyenteAsync(tipoContribuyente);
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateContribuyenteFiscalAsync(TipoContribuyente tipoContribuyente) =>
           await _service.UpdateTipoContribuyenteAsync(tipoContribuyente);

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Response<string>>> DeleteContribuyenteFiscalAsync(int id) =>
        //    await _service.DeleteTipoContribuyenteAsync(id);
    }
}