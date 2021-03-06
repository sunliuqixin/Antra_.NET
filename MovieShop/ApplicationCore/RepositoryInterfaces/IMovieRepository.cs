using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        //thod thats gonna get 30 highest revenue movies
        Task<IEnumerable<Movie>> GetTop30RevenueMovies();

        Task<Movie> GetMovieById(int id);

        Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize, int page);

        Task<IEnumerable<Movie>> GetUserPurchasesedMovies(int id);

        Task<IEnumerable<Movie>> GetUserFavoritedMovies(int id);

        Task<IEnumerable<Movie>> GetTopRatedMovies();

        Task<IEnumerable<Movie>> GetMoviesByGenreId(int id, int pagesize, int pageIndex);
    }
}
