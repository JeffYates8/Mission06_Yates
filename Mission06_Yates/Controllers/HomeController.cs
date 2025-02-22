using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Yates.Models;

namespace Mission06_Yates.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp)
        {
            _context = temp; // Assign the context to the private variable
        }

        public IActionResult Index()
        {
            return View(); // Return the default view
        }

        public IActionResult GettoKnowJoel()
        {
            return View(); // returns joel's bio view
        }

        [HttpGet]

        public IActionResult MovieForm() // This is the GET method for the MovieForm view
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", new MovieForm()); // creates a new MovieForm object and passes it to the view
        }

        [HttpPost]

        public IActionResult MovieForm(MovieForm response)
        {
            if (!ModelState.IsValid)
            {
                // Reload categories for the dropdown since they won't be available after validation failure
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response); // Return form with validation errors
            }
            else
            {
                // Only save to the database if the model is valid
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response); // Redirect to confirmation page
            }
            
        }

        public IActionResult MovieViewList()
        {
            //Linq
            var MovieList = _context.Movies // Get the list of movies from the database
                .Include(m => m.Category) // Include the Category navigation property
                .OrderBy(x => x.Title).ToList(); // Order by title

            return View(MovieList);
        }

        [HttpGet]
        public IActionResult Edit(int MovieId) // This is the GET method for the Edit view
        {
            var movieToEdit = _context.Movies // Get the movie to edit from the database
                .Single(x => x.MovieId == MovieId);

            ViewBag.Categories = _context.Categories // Get the list of categories from the database
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", movieToEdit); // Pass the movie to edit to the view
        }

        [HttpPost]
        public IActionResult Edit(MovieForm updatedInfo) // This is the POST method for the Edit view
        {
            _context.Update(updatedInfo); // Update the movie in the database
            _context.SaveChanges();

            return RedirectToAction("MovieViewList"); // Redirect to the MovieViewList view
        }

        [HttpGet]
        public IActionResult Delete(int MovieId) // This is the GET method for the Delete view
        {
            var movieToDelete = _context.Movies // Get the movie to delete from the database
                .Single(x => x.MovieId == MovieId);

            return View(movieToDelete); // Pass the movie to delete to the view
        }

        [HttpPost]
        public IActionResult Delete(MovieForm deletedInfo) // This is the POST method for the Delete view
        {
            _context.Movies.Remove(deletedInfo); // Remove the movie from the database
            _context.SaveChanges();

            return RedirectToAction("MovieViewList"); // Redirect to the MovieViewList view
        }
    }
}
