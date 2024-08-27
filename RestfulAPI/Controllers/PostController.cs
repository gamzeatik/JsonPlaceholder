using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;
using System.Net;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;
        private readonly IMapper _mapper;

        public PostController(IPostService service, IMapper mapper)
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
            // Post -> PostResponse
            var response = _mapper.Map<PostResponse>(createdPost);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _service.GetById(id);

            if (post == null) return NotFound();

            // Post -> PostResponse
            var response = _mapper.Map<PostResponse>(post);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _service.GetAll();

            if (posts == null || !posts.Any())
            {
                return NoContent();
            }
            // List<Post> -> List<PostResponse>
            var response = _mapper.Map<List<PostResponse>>(posts);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreatePostRequest request)
        {
            var existingPost = _service.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            _mapper.Map(request, existingPost);

            var updatedPost = _service.Update(id, existingPost);

            // Post -> PostResponse
            var response = _mapper.Map<PostResponse>(updatedPost);

            return Ok(response);
        }
    }
}
