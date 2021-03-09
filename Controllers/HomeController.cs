using IS_413_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Index view
        public IActionResult Index()
        {
            return View();
        }

        //podcasts view
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //get Movie form
        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        //post movie form that contains the model and doesn't show Independence day when directed to the list of movies in Archive.
        [HttpPost]
        public IActionResult NewMovie(NewMovieModel model)
        {
            //ensure the inputs are validated

            if (ModelState.IsValid)
            {
                //class, method, parameters. this adds a new moviemodel instance to the list!

                ArchiveModel.AddMovie(model);

                return View("Archive", ArchiveModel.AMovies.Where(model => model.Title != "Independence Day"));

            }
            else
            {
                return View();
            }
        }

        //Archive view that lists the movies entered except independence day
        public IActionResult Archive()
        {
            return View(ArchiveModel.AMovies.Where(model => model.Title != "Independence Day"));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
