using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Post
    {
        [Required]
        public int UserId { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Body { get; set; }
    }
}
