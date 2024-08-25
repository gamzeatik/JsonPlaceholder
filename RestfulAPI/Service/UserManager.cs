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
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }

        public User Update(int id, User user)
        {
            return _repository.UpdateById(id, user);
        }
    }
}
