using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // get view to AddMovie Page
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

            // Creates an instance that is passed to increment movie id
            return View(new AddMovie());
        }

        // Post to database
        [HttpPost]  
        public IActionResult AddMovie(AddMovie response)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the DB

                _context.SaveChanges(); // Save to DB

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Category)
                .ToList();

                return View(response);
            }

        }

        public IActionResult MovieList()
        {
            // Linq - query the data
            var movies = _context.Movies
                .Include(x => x.Category).ToList()
                //Title is a singular object
                .OrderBy(x => x.Title).ToList();
            // return the movies variable to the view
            return View(movies);
        }


        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // Load up categories in the edit route
            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Category)
            .ToList();

            return View("AddMovie", recordToEdit); 
        }

        [HttpPost]
        public IActionResult Edit(AddMovie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges(true);

            // Redirect to action so it passes in the data
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges(true);

            // Redirect to action so it passes in the data
            return RedirectToAction("MovieList");
        }

    }
}
