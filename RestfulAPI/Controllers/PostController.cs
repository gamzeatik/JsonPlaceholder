using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
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
        private readonly IMapper _mapper;

        public PostController(IPostsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreatePostRequest request)
        {
            // Map CreatePostRequest to Post
            var post = _mapper.Map<Post>(request);
            //post.UserId = GetUserIdFromSessionOrToken();
            post.UserId = 1;

            var createdPost = _service.Create(post);
            if (createdPost == null)
            {
                return BadRequest("Post could not be created.");
            }

            return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
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
