using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Requests
{
    public class CreatePhotoRequest
    {
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
    }
}
