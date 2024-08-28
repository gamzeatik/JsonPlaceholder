using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPI.DTOs.Requests;
using RestfulAPI.DTOs.Responses;
using RestfulAPI.Model;
using RestfulAPI.Service;

namespace RestfulAPI.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _service;
        private readonly IMapper _mapper;

        public PhotoController(IPhotoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreatePhotoRequest request)
        {
            var photo = _mapper.Map<Photo>(request);
            var createdPhoto = _service.Create(photo);
            var response = _mapper.Map<PhotoResponse>(createdPhoto);
            return CreatedAtAction(nameof(GetById), new { id = photo.Id }, response);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var photos = _service.GetAll();
            if (photos == null || !photos.Any())
            {
                return NoContent();
            }
            var response = _mapper.Map<List<PhotoResponse>>(photos);
            return Ok(response);
        }
        [HttpGet("by-album-id/{albumId}")]
        public IActionResult Get(int albumId)
        {
            var photos = _service.GetByAlbumId(albumId);
            if (photos == null || !photos.Any())
            {
                return NoContent();
            }
            var response = _mapper.Map<List<PhotoResponse>>(photos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var photo = _service.GetById(id);
            if (photo == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<PhotoResponse>(photo);
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
