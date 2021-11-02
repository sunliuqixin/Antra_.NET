using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {
        Task<List<GenreResponseModel>> GetAll();
        //Task GetMoviesByGenreId(int id);
        //Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int id);

    }
}