using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface IPhotoService
    {
        Photo Create(Photo photo);
        Photo GetById(int id);
        List<Photo> GetAll();
        void Delete(int id);
        List<Photo> GetByAlbumId(int albumId);
    }
}
