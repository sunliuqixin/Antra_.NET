using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }


        //this colum will not be in the movie table
        //average rating should come from review table
        public decimal? Rating { get; set; }


        //navigation property
        public ICollection<Trailer> Trailers { get; set; }
        public ICollection<MovieGenre> Genres { get; set; }

        public ICollection<MovieCast> Casts { get; set; }

        public ICollection<Review> RevUsers { get; set; }

        public ICollection<Favorite> FavUsers { get; set; }

        public ICollection<Purchase> PurUsers { get; set; }

 
    }
}
