using RestfulAPI.Model;

namespace RestfulAPI.DTOs.Requests
{
    public class CreateTodoRequest
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        public bool Comleted { get; set; } = false;
    }
}
