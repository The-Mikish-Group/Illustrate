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

        public IActionResult ImagesMenu()
        {
            return View();
        }

        public IActionResult Flowers()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View("Images");
        }

        public IActionResult Seashore()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View("Images");
        }

        public IActionResult Religious()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View("Images");
        }

        public IActionResult Misc()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View("Images");
        }

        public IActionResult Christmas()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View("Images");
        }

        public IActionResult Index()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View();
        } 

        public IActionResult Contact()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View();
        }

        public IActionResult Privacy()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;

            return View();
        }

        public IActionResult TOS()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
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