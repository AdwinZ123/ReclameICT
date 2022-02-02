using Microsoft.AspNetCore.Mvc;
using Opdracht_Programmeren.Models;
using System.Diagnostics;

namespace Opdracht_Programmeren.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact([Bind("Firstname", "LastName", "Mail", "Text", "PhoneNumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {

            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}