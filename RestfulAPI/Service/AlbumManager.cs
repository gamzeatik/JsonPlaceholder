using Microsoft.EntityFrameworkCore;
using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class AlbumManager : IAlbumService
    {
        private readonly IGenericRepository<Album> _repository;

        public AlbumManager(IGenericRepository<Album> repository)
        {
            _repository = repository;
        }

        public Album Create(Album album)
        {
            return _repository.Add(album);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }

        public List<Album> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<Album> GetAllWithPhotos()
        {
            return _repository.GetAll()
                .Include(m => m.Photos).ToList();
        }

        public Album GetById(int id)
        {
            return _repository.GetAll()
                .Include(m => m.Photos)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Album> GetByUserId(int userId)
        {
            return _repository.GetAll()
                .Where(m => m.UserId == userId).ToList();
        }

        public Album Update(int id, Album album)
        {
            return _repository.UpdateById(id, album);
        }
    }
}
