using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class PostManager : IPostService
    {
        private readonly IGenericRepository<Post> _repository;

        public PostManager(IGenericRepository<Post> repository)
        {
            _repository = repository;
        }

        public Post Create(Post post)
        {
            return _repository.Add(post);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }

        public List<Post> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Post GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Post Update(int id, Post post)
        {
            return _repository.UpdateById(id, post);
        }
    }
}
