using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Initilize the connection
        private mvCollectionRepository _mvCollectionRepository;
        private mvCollectionDbContext _mvCollectionDbContext;
        // Pass it thorugh
        public HomeController(ILogger<HomeController> logger, mvCollectionRepository mvCollectionRepository, mvCollectionDbContext mvCollectionDbContext)
        {
            _logger = logger;
            // Don't use this
            _mvCollectionRepository = mvCollectionRepository;
            // Storing in the Db
            _mvCollectionDbContext = mvCollectionDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Data()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Data(NewData MovieData)
        {
            //TempStorage.AddApplication(MovieData);
            _mvCollectionDbContext.NewDatas.Add(MovieData);
            _mvCollectionDbContext.SaveChanges();
            return View("Confirmation", MovieData);

        /*  if (ModelState.IsValid)
            {
                Response.Redirect("Home/Index");
            }
            return View()*/
        }

        [HttpPost]
        public IActionResult DeleteMovie(int movieId)
        {
            NewData Movie = _mvCollectionDbContext.NewDatas.First(x => x.MovieId == movieId);
            //NewData Movie = _mvCollectionDbContext.NewDatas.Find(MovieId);

            _mvCollectionDbContext.Remove(Movie);
            _mvCollectionDbContext.SaveChanges();
            return RedirectToAction("mvDB");
        }

        [HttpPost]
        public IActionResult EditMovie(int movieId)
        {
            NewData Movie = _mvCollectionDbContext.NewDatas.First(i => i.MovieId == movieId);

            //_mvCollectionDbContext.Update(Movie);
            //_mvCollectionDbContext.SaveChanges();
            return View("EditMovie", Movie);
        }


        [HttpPost]
        public IActionResult SaveChanges(NewData Movie, int movieId)
        {
            //Identify which movie corresponds to the id passed in 
            NewData MovieToOverwrite = _mvCollectionDbContext.NewDatas.Where(mr => mr.MovieId == movieId).FirstOrDefault();
            //var MovieToOverwrite = Movie.Where(mr => mr.MovieId == movieId).FirstOrDefault(); ;

            //Ensure form inputs are valid
            if (ModelState.IsValid)
            {
                //Update the values of the movie corresponding with the movieid passed in
                MovieToOverwrite.Category = Movie.Category;
                MovieToOverwrite.Title = Movie.Title;
                MovieToOverwrite.Year = Movie.Year;
                MovieToOverwrite.Director = Movie.Director;
                MovieToOverwrite.Rating = Movie.Rating;
                MovieToOverwrite.Edited = Movie.Edited;
                MovieToOverwrite.LentTo = Movie.LentTo;
                MovieToOverwrite.Notes = Movie.Notes;
            }
                //Save changes to the DB
                _mvCollectionDbContext.SaveChanges();

            //Route to view movies page; exclude Independence Day from being displayed
            return View("mvDB", _mvCollectionDbContext.NewDatas.Where(m => m.Title != "Independence Day"));
    

            //If model is invalid, return to same page - show validation violations
            //Not sure how to repass original movie data...
            //return View("mvDB", Movie);
            //}
        }


        public IActionResult mvDB()
        {
            return View ("mvDB", _mvCollectionDbContext.NewDatas);
            //return View(TempStorage.Applications);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
