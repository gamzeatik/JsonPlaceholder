namespace RestfulAPI.Repositories
{
    public interface IGenericRepository<T> where T : class, new()
    {
        T Add(T entity);
        T Delete(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();
        T UpdateById(int id, T entity);
    }
}
