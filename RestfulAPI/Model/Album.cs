using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        // Navigation Property
        public User User { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
