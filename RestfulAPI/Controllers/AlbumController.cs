using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateAlbumRequest request)
        {
            // Map CreateAlbumRequest to Albun
            var album = _mapper.Map<Album>(request);

            var createdAlbum = _service.Create(album);
            if (createdAlbum == null)
            {
                return BadRequest("Album could not be created.");
            }
            // Album -> AlbumResponse
            var response = _mapper.Map<AlbumResponse>(createdAlbum);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpGet("with-photos")]
        public IActionResult GetWithPhotos()
        {
            var albums = _service.GetAllWithPhotos();
            if (albums == null || !albums.Any())
            {
                return NoContent();
            }

            var response = _mapper.Map<List<AlbumResponse>>(albums);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var albums = _service.GetAll();
            if (albums == null || !albums.Any())
            {
                return NoContent();
            }

            var response = _mapper.Map<List<AlbumResponse>>(albums);
            return Ok(response);
        }
        [HttpGet("by-user-id/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var albums = _service.GetByUserId(userId);
            if (albums == null || !albums.Any())
            {
                return NoContent();
            }

            var response = _mapper.Map<List<AlbumResponse>>(albums);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var album = _service.GetById(id);
            if (album == null) return NotFound();

            var response = _mapper.Map<AlbumResponse>(album);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateAlbumRequest request)
        {
            var existingAlbum = _service.GetById(id);
            if (existingAlbum == null) return NotFound();
            _mapper.Map(request, existingAlbum);
            var updatedAlbum = _service.Update(id, existingAlbum);
            var response = _mapper.Map<AlbumResponse>(updatedAlbum);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
