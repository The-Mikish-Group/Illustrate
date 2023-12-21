using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class HomeController : Controller
    {

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
