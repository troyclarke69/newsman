using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsMan.Models;
using System.Diagnostics;

namespace NewsMan.Controllers
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
            // clear our cookie
            TempData.Clear();
            return View();
        }

        public IActionResult Privacy()
        {
            // clear our cookie
            TempData.Clear();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
