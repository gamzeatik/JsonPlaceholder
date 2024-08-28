using RestfulAPI.Model;
using RestfulAPI.Repositories;

namespace RestfulAPI.Service
{
    public class PhotoManager : IPhotoService
    {
        private readonly IGenericRepository<Photo> _repository;

        public PhotoManager(IGenericRepository<Photo> repository)
        {
            _repository = repository;
        }

        public Photo Create(Photo photo)
        {
            return _repository.Add(photo);
        }

        public void Delete(int id)
        {
            var value = _repository.GetById(id);
            _repository.Delete(value);
        }

        public List<Photo> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<Photo> GetByAlbumId(int albumId)
        {
            return _repository.GetAll()
                .Where(p => p.AlbumId == albumId).ToList();
        }

        public Photo GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
