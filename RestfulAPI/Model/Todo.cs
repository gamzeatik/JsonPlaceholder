using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAPI.Model
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int UserId { get; set; }
        public bool Comleted { get; set; } = false;
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
