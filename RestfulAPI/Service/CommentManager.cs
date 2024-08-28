using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class CommentManager : ICommentService
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentManager(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        public Comment Create(Comment comment)
        {
            return _repository.Add(comment);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }
        public List<Comment> GetCommentsByPostId(int postId)
        {
            return _repository.GetAll()
                .Where(c => c.PostId == postId).ToList();
        }
    }
}
