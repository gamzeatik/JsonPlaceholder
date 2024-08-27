using RestfulAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.DTOs.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressResponse Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyResponse Company { get; set; }
    }
}
