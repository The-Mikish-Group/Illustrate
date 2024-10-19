using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class ChopraController : Controller
    {
        protected IActionResult CustomView(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View();
        }

        public IActionResult Index() => CustomView("Chopra");        
    }
        
}
