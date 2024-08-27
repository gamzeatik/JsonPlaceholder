using RestfulAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Responses
{
    public class AlbumResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public ICollection<PhotoResponse> Photos { get; set; }
    }
}
