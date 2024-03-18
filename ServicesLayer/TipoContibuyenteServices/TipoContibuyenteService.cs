using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServicesLayer.DTO;
using ServicesLayer.ErrosServices;
using System.Reflection;

namespace ServicesLayer.TipoContibuyenteServices
{
    public class TipoContibuyenteService : ITipoContibuyenteService
    {
        private readonly IRepository<TipoContribuyente> _repository;
        private readonly IErrosService _erros;


        public TipoContibuyenteService(IRepository<TipoContribuyente> repository, IErrosService erros)
        {
            _repository = repository;
            _erros = erros;
        }

        public async Task<Response<TipoContribuyente>> GetAllAsync()
        {
            var response = new Response<TipoContribuyente>();
            try
            {
                response.DataList = _repository.GetAll();
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

        //public async Task<Response<TipoContribuyente>> GetTipoContribuyenteAsync(int id)
        //{
        //    var response = new Response<TipoContribuyente>();
        //    try
        //    {
        //        response.SingleData = _repository.Get(id);
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

        public async Task<Response<string>> SetTipoContribuyenteAsync(TipoContribuyente tipoContribuyente)
        {
            var response = new Response<string>();
            try
            {
                var isRegistered = _repository.GetAll().Any(x => x.Nombre == tipoContribuyente.Nombre);

                if (!isRegistered)
                {

                    _repository.Insert(tipoContribuyente);
                    response.Messages!.Add("Se agrego el tipo contribuyente exitosamente...");
                    response.Success = true;
                }
                else
                {
                    response.Messages!.Add($"Ya hay un tipo de contribuyente con este nombre...");

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

        public async Task<Response<string>> UpdateTipoContribuyenteAsync(TipoContribuyente tipoContribuyente)
        {
            var response = new Response<string>();
            try
            {
                var isRegistered = _repository.GetAll().Any(x => x.Id != tipoContribuyente.Id && (x.Nombre == tipoContribuyente.Nombre));

                if (!isRegistered)
                {

                    _repository.Update(tipoContribuyente);
                    response.Messages!.Add("Se actualizo el tipo contribuyecte corretamente...");
                    response.Success = true;
                }
                else
                {
                    response.Messages!.Add($"Ya existe un tipo de contribuyecte con este nombre...");
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

        //public async Task<Response<string>> DeleteTipoContribuyenteAsync(int id)
        //{
        //    var response = new Response<string>();
        //    try
        //    {
        //        var user = await GetTipoContribuyenteAsync(id);
        //        if (user.Success)
        //        {
        //            _repository.Delete(user.SingleData!);
        //            response.Success = true;
        //            response.Messages!.Add("El tipo de contribuyecte fue removido exitosamente...");
        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Messages!.Add("No fue encontrado el tipo de contribuyecte para su eliminación...");
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
