

using Microsoft.EntityFrameworkCore;
using RestfulAPI.Context;

namespace RestfulAPI.Repositories
{
    public class EfRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T UpdateById(int id, T entity)
        {
            var model = _dbSet.Find(id);
            if (model == null) return null;

            _context.Entry(model).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return model;

        }
    }
}
