using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        public MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.Casts).
                ThenInclude(m => m.Cast).Include(m => m.Genres).
                ThenInclude(m => m.Genre).Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            // First vs FirstOrDefault
            // Single vs SingleOrDefault
            // Single: 0 or more than one result will give exception
            // SingleOrDefault will accept 0 and 1 result
            // First accept 1 or more result
            // FirstOrDefault accept null or 0 results

            return movie;
        }

        public async Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreId(int id, int pagesize, int pageIndex)
        {
            var movies = await _dbContext.MovieGenres
                .Where(g => g.GenreId == id)
                .Include(m => m.Movie)
                .Skip( pagesize * (pageIndex-1) )
                .Take(pagesize)
                .Select( m => new Movie 
                    {
                        Id = m.MovieId,
                        PosterUrl = m.Movie.PosterUrl,
                        Title = m.Movie.Title,
                        ReleaseDate = m.Movie.ReleaseDate
                    })
                .ToListAsync();

            return movies;
        }


        //public async Task<PagedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1)
        //{
        //    var totalMoviesCountByGenre =
        //        await _dbContext.MovieGenres.Where(g => g.GenreId == genreId).CountAsync();

        //    if (totalMoviesCountByGenre == 0) throw new NotFoundException("NO Movies found for this genre");
        //    var movies = await _dbContext.MovieGenres.Where(g => g.GenreId == genreId)
        //        .Include(g => g.Movie).OrderByDescending(m => m.Movie.Revenue)
        //        .Select(m => new Movie
        //        {
        //            Id = m.MovieId,
        //            PosterUrl = m.Movie.PosterUrl,
        //            Title = m.Movie.Title,
        //            ReleaseDate = m.Movie.ReleaseDate
        //        })
        //        .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        //    return new PagedResultSet<Movie>(movies, pageIndex, pageSize, totalMoviesCountByGenre);
        //}



        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // we are gonna use EF with LINQ to get top 30 movies by revenue
            // SQL: SELECT top 30 * FROM MOVIES ORDER BY REVENUE
            // I/O bound operation
            // you can await only Tasks
            // EF and Dapper have both sync and async methods.
            var movies = await _dbContext.Movies.OrderByDescending
                (m => m.Revenue).Take(30).ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            // var movies = await _dbContext.Movies.OrderByDescending(m => m.Rating).Take(30).ToListAsync();
            // going to review table
            // movieid, title, posterurl, rating =>
            // 
            var movies = await _dbContext.Reviews.Include(r => r.Movie)
                .GroupBy(r => new { Id = r.MovieId, r.Movie.PosterUrl })
                .OrderByDescending(g => g.Average(m => m.Rating))
                .Select(m =>
                new Movie
                {
                    Id = m.Key.Id,
                    PosterUrl = m.Key.PosterUrl,
                    Rating = m.Average(x => x.Rating)
                }).Take(30).ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetUserFavoritedMovies(int id)
        {
            var movies = await _dbContext.Favorites.Where(f => f.UserId == id)
                .Select(f => f.Movie).ToListAsync();

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetUserPurchasesedMovies(int id)
        {
           

            //var movies = await _dbContext.Movies.Where(x => x.Id == id).ToListAsync();
            //var movies = await _dbContext.Movies.Include(m => m.PurUsers).Select(m=> m.pumovie.ToListAsync();
            var movies = await _dbContext.Purchases.Where(p => p.UserId == id).Select(p => p.Movie).ToListAsync();
            return movies;
        }
    }
}
