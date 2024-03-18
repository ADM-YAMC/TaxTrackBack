using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TaxTrackContext _dbContext;
        private DbSet<T> _entities;
        public Repository(TaxTrackContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException("entity");
            }
            _entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T Get(int id, params string[] navigationProperties)
        {
            IQueryable<T> query = _entities;

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query.SingleOrDefault(x => x.Id == id)!;
        }

        public IEnumerable<T> GetAll(params string[] navigationProperties)
        {
            IQueryable<T> query = _entities;

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }

            return query.AsEnumerable();
        }


        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException("entity");
            }
            _entities.Add(entity);
            _dbContext.SaveChanges();
        }


        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException("entity");
            }
            _entities.Remove(entity);
        }

        public async void SaveChanges()
            => await _dbContext.SaveChangesAsync();


        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentOutOfRangeException("entity");
            }
            _entities.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
