using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface IUserService
    {
        User Create(User user);
        User GetById(int id);
        List<User> GetAll();
        void Delete(int id);
        User Update (int id, User user);
    }
}
