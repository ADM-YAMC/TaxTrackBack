using DomainLayer.Models;

namespace RepositoryLayer.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params string[] navigationProperties);
        T Get(int id, params string[] navigationProperties);
        //T GetForIdentification(string Identification);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
