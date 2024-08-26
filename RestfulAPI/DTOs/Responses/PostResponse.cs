using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Responses
{
    public class PostResponse
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
