using Microsoft.AspNetCore.Mvc;
using Mission6_GarrettAshcroft.Models;
using SQLitePCL;
using System.Diagnostics;

namespace Mission6_GarrettAshcroft.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;
        public HomeController(AddMovieContext temp)
        {
            _context = temp;
        }


/*        private readonly ILogger<HomeController> _logger;*/

/*        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult AddMovie(AddMovie response)
        {
            _context.Movies.Add(response);

            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
