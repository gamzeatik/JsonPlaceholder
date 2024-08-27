using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Requests
{
    public class CreateAlbumRequest
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
    }
}
