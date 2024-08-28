using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface ICommentService
    {
        Comment Create(Comment comment);
        void Delete(int id);
        List<Comment> GetCommentsByPostId(int postId);
    }
}
