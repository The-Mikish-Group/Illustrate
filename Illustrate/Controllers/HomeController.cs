using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
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
            ViewData["ViewName"] = "Home";
            return View();
        }

        public IActionResult Contact()
        {            
            ViewData["ViewName"] = "Contact";
            return View();
        }

        public IActionResult Privacy()
        {           
            ViewData["ViewName"] = "Privacy";
            return View();
        }

        public IActionResult TOS()
        {            
            ViewData["ViewName"] = "Terms of Service";
            return View();
        }
        public IActionResult FoldersMenu()
        {            
            ViewData["ViewName"] = "Image Folders Menu";
            return View();
        }

        public IActionResult Images(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View();
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
