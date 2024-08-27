using RestfulAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        public CreateAddressRequest Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CreateCompanyRequest Company { get; set; }
    }
}
