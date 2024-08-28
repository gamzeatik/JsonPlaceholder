using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface ITodoService
    {
        List<Todo> GetAll();
        Todo GetById(int id);
        Todo Create(Todo todo);
        void Delete(int id);
        List<Todo> GetByUserId(int userId);
        Todo Update(int id, Todo todo);
    }
}
