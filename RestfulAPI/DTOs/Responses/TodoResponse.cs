using RestfulAPI.Model;

namespace RestfulAPI.DTOs.Responses
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public bool Comleted { get; set; } = false;
    }
}
