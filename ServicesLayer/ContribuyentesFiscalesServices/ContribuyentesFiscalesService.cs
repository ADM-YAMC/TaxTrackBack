using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServicesLayer.DTO;
using ServicesLayer.ErrosServices;
using System.Reflection;

namespace ServicesLayer.ContribuyentesFiscalesServices
{
    public class ContribuyentesFiscalesService : IContribuyentesFiscalesService
    {
        private readonly IRepository<ContribuyenteFiscal> _repository;
        private readonly IErrosService _erros;
        public decimal Itbis18 { get; set; } = 0.18M;

        public ContribuyentesFiscalesService(IRepository<ContribuyenteFiscal> repository, IErrosService erros)
        {
            _repository = repository;
            _erros = erros;
        }
        public async Task<Response<ContribuyenteFiscal>> GetAllAsync()
        {
            var response = new Response<ContribuyenteFiscal>();
            try
            {
                response.DataList = _repository.GetAll("TipoContribuyentes", "ComprobantesFiscales");
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors!.Add(e.Message);
                _erros.SetErrors(new Erros
                {
                    MetodoBase = MethodBase.GetCurrentMethod()!.ReflectedType!.FullName!,
                    Mensaje = e.Message,
                    StackTrace = e.StackTrace!,
                    Usuario = "Admin",
                    Tipo = e.GetType().Name
                });
            }
            return await Task.Run(() => response);
        }

        //public async Task<Response<ContribuyenteFiscal>> GetContribuyenteFiscalAsync(int id)
        //{
        //    var response = new Response<ContribuyenteFiscal>();
        //    try
        //    {
        //        response.SingleData = _repository.Get(id, "TipoContribuyentes", "ComprobantesFiscales");
        //        response.Success = true;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.Errors!.Add(e.Message);
        //        _erros.SetErrors(new Erros
        //        {
        //            MetodoBase = MethodBase.GetCurrentMethod()!.ReflectedType!.FullName!,
        //            Mensaje = e.Message,
        //            StackTrace = e.StackTrace!,
        //            Usuario = "Admin",
        //            Tipo = e.GetType().Name
        //        });
        //    }
        //    return await Task.Run(() => response);
        //}

        public async Task<Response<string>> SetContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente)
        {
            var response = new Response<string>();
            try
            {
                var isRegistered = _repository.GetAll().Any(x => x.RncCedula == contribuyente.RncCedula);

                if (!isRegistered)
                {
                    contribuyente.ComprobantesFiscales.ForEach(comp =>
                    {
                        comp.Itbis18 = comp.Monto * Itbis18;
                    });
                    _repository.Insert(contribuyente);
                    response.Messages!.Add("Se agrego el contribuyente exitosamente...");
                    response.Success = true;
                }
                else
                {
                    response.Messages!.Add($"Ya hay un contribuyente con este RNC o Cédula No.{contribuyente.RncCedula}...");

                    response.Success = false;
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors!.Add(e.Message);
                _erros.SetErrors(new Erros
                {
                    MetodoBase = MethodBase.GetCurrentMethod()!.ReflectedType!.FullName!,
                    Mensaje = e.Message,
                    StackTrace = e.StackTrace!,
                    Usuario = "Admin",
                    Tipo = e.GetType().Name
                });
            }
            return await Task.Run(() => response);
        }

        public async Task<Response<string>> UpdateContribuyenteFiscalAsync(ContribuyenteFiscal contribuyente)
        {
            var response = new Response<string>();
            try
            {
                var isRegistered = _repository.GetAll().Any(x => x.Id != contribuyente.Id && (x.RncCedula == contribuyente.RncCedula));

                if (!isRegistered)
                {

                    contribuyente.ComprobantesFiscales.ForEach(comp =>
                    {
                        comp.Itbis18 = comp.Monto * Itbis18;
                    });
                    _repository.Update(contribuyente);
                    response.Messages!.Add("Se actualizo el contribuyecte corretamente...");
                    response.Success = true;
                }
                else
                {
                    response.Messages!.Add($"Ya existe un contribuyecte con este RNC o Cédula No.{contribuyente.RncCedula}.");
                    response.Success = false;
                }

            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors!.Add(e.Message);
                _erros.SetErrors(new Erros
                {
                    MetodoBase = MethodBase.GetCurrentMethod()!.ReflectedType!.FullName!,
                    Mensaje = e.Message,
                    StackTrace = e.StackTrace!,
                    Usuario = "Admin",
                    Tipo = e.GetType().Name
                });
            }
            return await Task.Run(() => response);
        }

        //public async Task<Response<string>> DeleteContribuyenteFiscalAsync(int id)
        //{
        //    var response = new Response<string>();
        //    try
        //    {
        //        var user = await GetContribuyenteFiscalAsync(id);
        //        if (user.Success)
        //        {
        //            _repository.Delete(user.SingleData!);
        //            response.Success = true;
        //            response.Messages!.Add("El contribuyecte fue removido exitosamente...");
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Messages!.Add("No fue encontrado el contribuyecte para su eliminación...");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        response.Success = false;
        //        response.Errors!.Add(e.Message);
        //        _erros.SetErrors(new Erros
        //        {
        //            MetodoBase = MethodBase.GetCurrentMethod()!.ReflectedType!.FullName!,
        //            Mensaje = e.Message,
        //            StackTrace = e.StackTrace!,
        //            Usuario = "Admin",
        //            Tipo = e.GetType().Name
        //        });
        //    }

        //    return response;
        //}

    }
}
