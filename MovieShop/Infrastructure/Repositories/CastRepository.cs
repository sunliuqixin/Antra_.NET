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
    public class CastRepository : ICastRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public CastRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MovieCast> GetCastById(int castId)
        {
            var movieCast = await _dbContext.MovieCasts.Where(c => c.CastId == castId)
                .Include(c => c.Cast).FirstOrDefaultAsync();

            //var temp = await from c in _dbContext.Casts join m in _dbContext.MovieGenres on c.Id equals
            
            return movieCast;
        }
    }
}
