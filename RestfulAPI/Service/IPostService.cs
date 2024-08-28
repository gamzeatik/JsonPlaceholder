using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface IPostService
    {
        Post Create(Post post);
        Post GetById(int id);
        List<Post> GetAll();
        void Delete(int id);
        Post Update(int id, Post posts);
        List<Post> GetByUserId(int userId);
    }
}
