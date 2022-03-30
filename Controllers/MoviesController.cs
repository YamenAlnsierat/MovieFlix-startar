using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieflix_api.Data;
using movieflix_api.Models;
using movieflix_api.ViewModels;

namespace movieflix_api.Controllers
{
  [ApiController]
  [Route("api/v1/movies")] //Url till Endpoint(resursen = movies)
  public class MoviesController : ControllerBase
  {
    private readonly DataContext _context;
    public MoviesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet()]
    public async Task<ActionResult<List<ListMoviesViewModel>>> ListMovies()
    {
      var movies = await _context.Movies.ToListAsync();
      var movieList = new List<ListMoviesViewModel>();

      foreach (var movie in movies)
      {
        movieList.Add(new ListMoviesViewModel{
             MovieId = movie.Id,
        Title = movie.Title,
        ReleaseYear = movie.ReleaseYear,
        Length = movie.Length,
        Director = movie.Director,
        Genre = movie.Genre.GenreName,
        ImageUrl = movie.ImageUrl
        }); 
      }

      return Ok(movieList);
    }

    [HttpGet("{title}")]
    public ActionResult<string> GetMovie(string title)
    {
      return Ok("Batman Begins");
    }

    [HttpPost()]
    public async Task<ActionResult<ListMoviesViewModel>> AddMovie(PostMovieViewModel model)
    {
      var newMovie = new Movie{
        Title = model.Title,
        ReleaseYear = model.ReleaseYear,
        Length = model.Length,
        Director = model.Director,
        ImageUrl = model.ImageUrl
      };

      var genre = await _context.Genres.FirstOrDefaultAsync( c => c.GenreName == model.Genre);

      if(genre is null){
        return NotFound($"Kunde inte hitta non genre med namnet: {model.Genre}");
      }
      newMovie.Genre = genre;

      _context.Movies.Add(newMovie);
      await _context.SaveChangesAsync();

      var responsModel = new ListMoviesViewModel{
        MovieId = newMovie.Id,
        Title = newMovie.Title,
        ReleaseYear = newMovie.ReleaseYear,
        Length = newMovie.Length,
        Director = newMovie.Director,
        ImageUrl = newMovie.ImageUrl
      };

      return StatusCode(201, responsModel);
    }
  }
}