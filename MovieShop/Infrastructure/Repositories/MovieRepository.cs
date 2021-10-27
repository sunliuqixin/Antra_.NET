﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
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
        public IEnumerable<Movie> GetTop30RevenueMovies()
        {
            // we are gonna use EF with LINQ to get top 30 movies by revenue
            // SQL: SELECT top 30 * FROM MOVIES ORDER BY REVENUE

            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;

        }
    }
}
