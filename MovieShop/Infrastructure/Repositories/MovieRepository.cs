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
    }
}
