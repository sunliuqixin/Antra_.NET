using ApplicationCore.RepositoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{

    //all the action methods in user controller
    //works only when user login sucesses
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;

        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]

        [Authorize]
        public async Task<IActionResult> Purchase() 
        {
            //purchase a movie when user clicks
            //on buy botton on moviedetails page

            return View();
        }

        [HttpPost]

        [Authorize]
        public async Task<IActionResult> Favorite(int id)
        {
            // favorite a movie when user
            // clicks on movieDetail page
            return View();
        }


        [HttpGet]
        // Filters in ASP.NET 
        [Authorize]
        public async Task<IActionResult> Purchases(int id)
        {
            // get the id from HttpCOntext.User.Claims
            /*var userIdentity = this.User.Identity;
            if (userIdentity != null && userIdentity.IsAuthenticated)
            {
                // call the databsae to get the data
                return View();
            }
            

            RedirectToAction("Login", "Account");*/
            // get all the movies purchased by user => List<MovieCard> 
            //var userIdentity = this.User.Identity;
            //int userId = Convert.ToInt32((HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
            //if (userIdentity != null && userIdentity.IsAuthenticated)
            //

            //}
            //var movies = movieRepository.GetUserPurchasesedMovies(userId);
            // call userservie that will give list of moviesCard Models that this user purchased
            // Purchase, dbContext.Purchase.where(u=> u.UserId == id);
            //ViewData["Movies"] = movies;

            var userId = _currentUserService.UserId;
            // pass the userid to the userService which will 
            // pass to userRepository
            return View();

        }

        [HttpGet]

        [Authorize]
        public async Task<IActionResult> Favorites(int id)
        {
            //get all the movies favorited by user => List<MovieCard>
            return View();
        }

        [HttpGet]

        [Authorize]
        public async Task<IActionResult> Reviews(int id)
        {
            //get all the reviews done by user 
            return View();
        }

        [HttpPost]

        [Authorize]
        public async Task<IActionResult> Review(int id)
        {
            //add a new review done by the user
            return View();
        } 
    }
}
