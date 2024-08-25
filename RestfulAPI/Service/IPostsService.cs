using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface IPostsService
    {
        Post Create(Post post);
        Post GetById(int id);
        List<Post> GetAll();
        void Delete(int id);
        Post Update(int id, Post posts);
    }
}
