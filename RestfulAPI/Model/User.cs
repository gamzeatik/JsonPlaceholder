using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Todo> Todos { get; set; }
    }
}
