using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;
using System.IO;

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
        public IActionResult FoldersMenu()
        {
            string viewName = ControllerContext.ActionDescriptor.ActionName;
            ViewData["ViewName"] = viewName;
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
