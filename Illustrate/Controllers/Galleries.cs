using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class GalleriesController : Controller
    {

        public IActionResult Index()
        {           
            ViewData["ViewName"] = "Galleries";
            return View();
        }  
       
    }
}
