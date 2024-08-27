using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Photo
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        [Url]
        public string ThumbnailUrl { get; set; }

        // Navigation Property
        public Album Album { get; set; }
    }
}
