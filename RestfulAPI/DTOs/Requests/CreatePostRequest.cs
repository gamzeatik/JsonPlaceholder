using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Requests
{
    public class CreatePostRequest
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
    }
}
