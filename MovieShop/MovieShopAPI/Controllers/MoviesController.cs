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
        private readonly IGenreService _genreService;

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

        //[HttpGet]
        //[Route("/Genre/id:int")]
        //public async Task<IActionResult> Genre(int id)
        //{
        //    var moviecards = await _genreService.GetMoviesByGenreId(id);

        //    if (moviecards == null)
        //    {
        //        return NotFound("No movies found for Genre");
        //    }

        //    return Ok(moviecards);
        //}
    }
}
