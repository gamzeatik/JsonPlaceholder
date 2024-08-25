using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Model;
using RestfulAPI.Service;
using System.Net;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostsService _service;

        public PostController(IPostsService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            var response = _service.Create(post);
            if (response == null)
            {
                return BadRequest("Post could not be created.");
            }

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
        public IActionResult Update(int id, Post post)
        {
            var response = _service.Update(id, post);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
