using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
