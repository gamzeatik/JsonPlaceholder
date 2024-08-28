using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;
        private readonly IMapper _mapper;

        public TodoController(ITodoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var todos = _service.GetAll();
            if (todos == null || !todos.Any())
            {
                return NoContent();
            }
            var response = _mapper.Map<List<TodoResponse>>(todos);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create(CreateTodoRequest request)
        {
            var todo = _mapper.Map<Todo>(request);
            var createdTodo = _service.Create(todo);

            if (createdTodo == null) return BadRequest(createdTodo);

            var response = _mapper.Map<TodoResponse>(createdTodo);
            return CreatedAtAction(nameof(Create), request, response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _service.GetById(id);
            if (todo == null) return NotFound();

            var response = _mapper.Map<TodoResponse>(todo);
            return Ok(response);
        }
        [HttpGet("by-user-id/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var todos = _service.GetByUserId(userId);
            if (todos == null || !todos.Any()) { return NoContent(); }

            var response = _mapper.Map<List<TodoResponse>>(todos);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateTodoRequest request)
        {
            var existingTodo = _service.GetById(id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            _mapper.Map(request, existingTodo);
            var updatedTodo = _service.Update(id, existingTodo);
            var response = _mapper.Map<TodoResponse>(updatedTodo);
            return Ok(response);
        }

    }
}
