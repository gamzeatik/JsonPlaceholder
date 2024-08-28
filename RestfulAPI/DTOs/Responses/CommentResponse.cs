using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
