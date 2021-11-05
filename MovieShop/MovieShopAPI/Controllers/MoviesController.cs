using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        // create an api method that shows top 30 revenue/grossing movies
        // so that my SPA, iOS and Android app show those movies in the home screen

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // create the api method that shows top 30 movies , json data

        [HttpGet]
        [Route("toprevenue")]
        // Attribute based routing
        // http://localhost/api/movies/toprevenue
        // API
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

            // for coverting C# objects to Json objects there are 2 ways
            // before .NET Core 3, we used NewtonSoft.Json library
            // Mirosoft created their own JSON Serialization library
            // System.Text.Json

        }

        [HttpGet]
        [Route("toprated")]

        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();

            // JSON data and Http Status Code //

            if (!movies.Any())
            {
                // return 404
                return NotFound("No Movies Found");
            }

            // 200 OK
            return Ok(movies);

        }


        // http://localhost/api/movies/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null) return NotFound($"No movie found for {id}");
            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        // http://localhost:5001/api/movies/genre/5?pagesize=30&pageIndex=35
        // many movies belonging to a genre=> 
        // pagination 
        // 2000 movies for 5
        // 30 movies per page =>
        // show how many page number
         // 2000/30 => 67 pages
        public async Task<IActionResult> GetMoviesByGenres(int genreId, [FromQuery] int pagesize =30, [FromQuery] int pageIndex=1)
        {
            // 1 to 30 rows
            // click on page 2 => 31 to 60
            // 3 => 61 to 90
            // LINQ moviegenres.skip(pageindex-1).take(pagesize).tolistasync()
            // offset 0 and fetch next 30
            // server - side pagination
            var movies = await _movieService.GetMoviesByGenreId(genreId, pagesize, pageIndex);

            if (movies == null)
            {
                return NotFound("No movies found for Genre");
            }

            return Ok(movies);
        }

        
    }
}
