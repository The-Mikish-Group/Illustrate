using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class APController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ViewName"] = "Galleries";
            return View();
        }    

        public IActionResult Gallery(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View("Gallery");
        }
        
    }
}
