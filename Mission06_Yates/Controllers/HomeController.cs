using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Yates.Models;

namespace Mission06_Yates.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GettoKnowJoel()
        {
            return View();
        }

        [HttpGet]

        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm", new MovieForm());
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
    }
}
