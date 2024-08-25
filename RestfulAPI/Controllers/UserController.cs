using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var response = _service.Create(user);
            if (response == null) return BadRequest(response);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _service.GetAll();
            if (response == null || !response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            var response = _service.Update(id, user);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
