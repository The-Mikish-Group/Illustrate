using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class MVController : Controller
    {
        private readonly ILogger<MVController> _logger;

        public MVController(ILogger<MVController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {           
            ViewData["ViewName"] = "Home";
            return View("ImagesMenu");
        }
       
        public IActionResult ImagesMenu()
        {            
            ViewData["ViewName"] = "Image Folders";
            return View();
        }

        public IActionResult Images(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View("Images");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
