using RestfulAPI.Model;

namespace RestfulAPI.Service
{
    public interface IAlbumService
    {
        Album Create(Album album);
        Album GetById(int id);
        Album Update(int id, Album album);
        List<Album> GetAllWithPhotos();
        List<Album> GetAll();
        void Delete(int id);
        List<Album> GetByUserId(int userId);

    }
}
