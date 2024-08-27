using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            // CreateUserRequest -> User
            var user = _mapper.Map<User>(request);
            var createdUser = _service.Create(user);

            if (createdUser == null) return BadRequest(createdUser);
            var response = _mapper.Map<UserResponse>(createdUser);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _service.GetById(id);
            if (user == null) return NotFound();
            // User -> UserResponse
            var response = _mapper.Map<UserResponse>(user);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _service.GetAll();
            if (users == null || !users.Any())
            {
                return NoContent();
            }

            // List<User> -> List<UserResponse>
            var response = _mapper.Map<List<UserResponse>>(users);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateUserRequest request)
        {
            var existingUser = _service.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(request, existingUser);

            var updatedUser = _service.Update(id, existingUser);
            var response = _mapper.Map<UserResponse>(updatedUser);

            return Ok(response);
        }
    }
}
