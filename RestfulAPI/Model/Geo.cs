using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Geo
    {
        [Key] 
        public int Id { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
