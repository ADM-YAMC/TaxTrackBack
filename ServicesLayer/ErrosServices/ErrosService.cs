using DomainLayer.Models;
using RepositoryLayer.Repository;

namespace ServicesLayer.ErrosServices
{
    public class ErrosService : IErrosService
    {
        private readonly IRepository<Erros> _repository;

        public ErrosService(IRepository<Erros> repository)
        {
            _repository = repository;
        }
        public void SetErrors(Erros erros)
        {
            try
            {
                _repository.Insert(erros);
            }
            catch (Exception)
            {
            }
        }
    }
}
