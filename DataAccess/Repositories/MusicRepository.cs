using DataAccess.DataAccess;
using DataAccess.Repositories.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class MusicRepository : IMusicRepository
{
    private readonly DataContext _context;

    public MusicRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Music> GetAll()
    {
        return _context.Musics.AsQueryable().ToList();
    }

    public Music GetById(int id)
    {
        return _context.Musics.Include(x=> x.Artist).FirstOrDefault();
    }

    public void Create(Music music)
    {
        // Get the artist from the database.
        Artist artist = _context.Artists.FirstOrDefault(a => a.Id == music.Artist.Id);

        // If the artist is not found, throw an exception.
        if (artist == null)
        {
            throw new ArgumentException("The artist does not exist.");
        }

        // Set the Artist property of the Music object.
        music.Artist = artist;

        // Add the Music object to the database.
        _context.Musics.Add(music);
        _context.SaveChanges();
    }

    public void Update(Music music)
    {
        _context.Entry(music).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Music music = _context.Musics.Find(id);
        _context.Musics.Remove(music);
        _context.SaveChanges();
    }

    public IEnumerable<Music> GetAllMusicsWithArtist()
    {
        var musics = _context.Musics.Include(m => m.Artist);

        return musics.ToList();
    }

    public IEnumerable<Music> GetMusicByArtist(string artist)
    {
        var musics = _context.Musics.Where(m => m.Artist.Name == artist).Include(a => a.Artist);

        return musics.ToList();
    }
}

