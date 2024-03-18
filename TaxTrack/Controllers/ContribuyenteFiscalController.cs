using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ContribuyentesFiscalesServices;
using ServicesLayer.DTO;

namespace TaxTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteFiscalController : ControllerBase
    {
        private readonly IContribuyentesFiscalesService _service;

        public ContribuyenteFiscalController(IContribuyentesFiscalesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Response<ContribuyenteFiscal>>> GetAll() =>
         await _service.GetAllAsync();

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Response<ContribuyenteFiscal>>> Get(int id) =>
        //    await _service.GetContribuyenteFiscalAsync(id);

        [HttpPost]
        public async Task<ActionResult<Response<string>>> AddContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente) =>
            await _service.SetContribuyenteFiscalAsync(contribuyente);
        [HttpPut]
        public async Task<ActionResult<Response<string>>> UpdateContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente) =>
           await _service.UpdateContribuyenteFiscalAsync(contribuyente);

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Response<string>>> DeleteContribuyenteFiscalAsync(int id) =>
        //    await _service.DeleteContribuyenteFiscalAsync(id);
    }
}
