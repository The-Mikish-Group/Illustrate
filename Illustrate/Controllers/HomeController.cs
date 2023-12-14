using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Illustrate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
         
        public IActionResult Coasters()
        {            
            return View();
        }

        public IActionResult Flowers()
        {
            return View();
        }

        public IActionResult Seashore()
        {
            return View();
        }

        public IActionResult Religious()
        {
            return View();
        }

        public IActionResult Misc()
        {
            return View();
        }

        public IActionResult Christmas()
        {
            return View();
        }

        public IActionResult Index()
        {           
            return View();
        } 

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TOS()
        {
            return View();
        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}