using DataAccess.Repositories.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoreWithAngular.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MusicController : Controller
{
    private readonly IMusicRepository _musicRepository;

    public MusicController(IMusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }

    [HttpPost]
    [Route("/CreateMusic")]
    public IActionResult Create(Music music)
    {
        if (ModelState.IsValid)
        {
            _musicRepository.Create(music);
            return Ok();
        }

        return Ok(music);
    }

    [HttpGet]
    [Route("/GetMusicById")]
    public IActionResult GetmusicById(int id)
    {
        Music music = _musicRepository.GetById(id);

        return Ok(music);
    }

    [HttpGet]
    [Route("/GetAllMusics")]
    public IActionResult GetMusics()
    {
        IEnumerable<Music> musics = _musicRepository.GetAllMusicsWithArtist();
        return Ok(musics);
    }

    [HttpGet]
    [Route("/GetMusicByArtist")]
    public IActionResult GetMusic(string srtist)
    {
        var musics = _musicRepository.GetMusicByArtist(srtist);

        return Ok(musics);
    }
}

