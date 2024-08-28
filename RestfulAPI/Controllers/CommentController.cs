using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCommentRequest request)
        {
            var comment = _mapper.Map<Comment>(request);
            var createdComment = _service.Create(comment);
            if (createdComment == null) return BadRequest("Comment could not be created");

            var response = _mapper.Map<CommentResponse>(createdComment);
            return Ok(response);
        }

        [HttpGet("by-post-id/{postId}")]
        public IActionResult GetCommentsByPostId(int postId)
        {
            var comments = _service.GetCommentsByPostId(postId);
            if (comments == null || !comments.Any()) return NoContent();

            var response = _mapper.Map<List<CommentResponse>>(comments);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComments(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

    }
}
