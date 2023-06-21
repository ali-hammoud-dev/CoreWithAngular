using Domain.Model;

namespace DataAccess.Repositories.Interface;

public interface IMusicRepository : IBaseRepository<Music>
{
    IEnumerable<Music> GetAllMusicsWithArtist();

    IEnumerable<Music> GetMusicByArtist(string artist);

}

