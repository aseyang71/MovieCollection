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
            // Don't need to use this, I keep here for personal notes
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

        
        public IActionResult EditMovie(int movieId)
        {
            // Use "movieId" to identify which movie record we will open the edit form for. 
            NewData movie = _mvCollectionDbContext.NewDatas.First(i => i.MovieId == movieId);

            // Take the user to the Edit form where they can modify each record 
            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie(NewData movie, int movieId)
        {
            // Store the movie object that we want to modify that has the same id(used to verify if it's the same record) to be able to write shorter code below. 
            var UpdatedMV = _mvCollectionDbContext.NewDatas.FirstOrDefault(i => i.MovieId == movieId);

            // For note taking 
            // var UpdatedMV = _mvCollectionDbContext.NewDatas.Single(i => i.MovieId == movieId);
            // var UpdatedMV = _mvCollectionDbContext.NewDatas.First(i => i.MovieId == movieId);

            // Make sure the variable is now storing the object and the Model is valid
            if (UpdatedMV != null && ModelState.IsValid)
            {

                // Update each property of that movie 
                UpdatedMV.Category = movie.Category;
                UpdatedMV.Title = movie.Title;
                UpdatedMV.Year = movie.Year;
                UpdatedMV.Rating = movie.Rating;
                UpdatedMV.Edited = movie.Edited;
                UpdatedMV.LentTo = movie.LentTo;
                UpdatedMV.Notes = movie.Notes;

                //Save changes to the DB
                _mvCollectionDbContext.SaveChanges();

                //Route to view movies page
                return RedirectToAction("mvDB");
            }
            else
                return View("Index");


            // For note taking

            //var UpdatedMV = _mvCollectionDbContext.NewDatas.First(i => i.MovieId == movieId);
            //var UpdatedMV = _mvCollectionDbContext.NewDatas.Single(x => x.MovieId == movieId);

/*          _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Category).CurrentValue = movie.Category;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Title).CurrentValue = movie.Title;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Year).CurrentValue = movie.Year;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Rating).CurrentValue = movie.Rating;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Edited).CurrentValue = movie.Edited;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.LentTo).CurrentValue = movie.LentTo;
            _mvCollectionDbContext.Entry(UpdatedMV).Property(x => x.Notes).CurrentValue = movie.Notes;*/
        }

        public IActionResult mvDB()
        {
            return View ("mvDB", _mvCollectionDbContext.NewDatas);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
