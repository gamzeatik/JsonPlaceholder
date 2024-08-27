using Microsoft.EntityFrameworkCore;
using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class UserManager : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserManager(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Add(user);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }

        public List<User> GetAll()
        {
            return _repository.GetAll()
                .Include(m => m.Address)
                .Include(m => m.Address.Geo)
                .Include(m => m.Company).ToList();
        }

        public User GetById(int id)
        {
            return _repository.GetAll()
                .Include(m => m.Address)
                .Include(a => a.Address.Geo)
                .Include(m => m.Company)
                .FirstOrDefault(u => u.Id == id);
        }

        public User Update(int id, User user)
        {
            return _repository.UpdateById(id, user);
        }
    }
}
