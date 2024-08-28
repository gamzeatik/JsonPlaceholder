using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Requests
{
    public class CreateCommentRequest
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
