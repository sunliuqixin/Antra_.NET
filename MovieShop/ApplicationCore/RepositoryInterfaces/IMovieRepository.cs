﻿using ApplicationCore.Entities;
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
        IEnumerable<Movie> GetTop30RevenueMovies();

    }
}
