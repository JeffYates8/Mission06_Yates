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
            return View();
        }

        [HttpPost]

        public IActionResult MovieForm(MovieForm response)
        {
            _context.MovieForm.Add(response); // adds record to DB
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
