using Microsoft.EntityFrameworkCore;
using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class TodoManager : ITodoService
    {
        private readonly IGenericRepository<Todo> _repository;

        public TodoManager(IGenericRepository<Todo> repository)
        {
            _repository = repository;
        }
        public Todo Create(Todo todo)
        {
            return _repository.Add(todo);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }

        public List<Todo> GetAll()
        {
            return _repository.GetAll()
                .Include(m => m.User).ToList();
        }

        public Todo GetById(int id)
        {
            return _repository.GetAll()
                .Include(m => m.User)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Todo> GetByUserId(int userId)
        {
            return _repository.GetAll()
                .Include(m => m.User)
                .Where(a => a.UserId == userId).ToList();
        }

        public Todo Update(int id, Todo todo)
        {
            return _repository.UpdateById(id, todo);
        }
    }
}
