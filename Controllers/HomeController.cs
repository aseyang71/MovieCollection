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
        public IActionResult DeleteMovie(int Id)
        {
            NewData Movie = _mvCollectionDbContext.NewDatas.First(x => x.MovieId == Id);
            _mvCollectionDbContext.Remove(Movie);
            _mvCollectionDbContext.SaveChanges();
            return RedirectToAction("mvDB");
        }

        public IActionResult mvDB()
        {
            return View (_mvCollectionDbContext.NewDatas);
            //return View(TempStorage.Applications);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
