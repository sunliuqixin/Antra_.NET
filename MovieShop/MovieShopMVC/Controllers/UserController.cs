using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{

    //all the action methods in user controller
    //works only when user login sucesses
    public class UserController : Controller
    {
      
        [HttpPost]
        public async Task<IActionResult> Purchase() 
        {
            //purchase a movie when user clicks
            //on buy botton on moviedetails page

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Favorite(int id)
        {
            // favorite a movie when user
            // clicks on movieDetail page
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Purchases(int id)
        {
            //get all the movies purchased by user => List<MovieCard>
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites(int id)
        {
            //get all the movies favorited by user => List<MovieCard>
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            //get all the reviews done by user 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Review(int id)
        {
            //add a new review done by the user
            return View();
        } 
    }
}
