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
    public class GenreRepository : IGenreRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public GenreRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Genre> GetById(int id)
        {
            var genre = await _dbContext.Genres
                .Include(g => g.Movies)
                .FirstOrDefaultAsync(g => g.Id == id);

            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            var genre = await _dbContext.Genres.ToListAsync();

            return genre;
        }
    }
}
