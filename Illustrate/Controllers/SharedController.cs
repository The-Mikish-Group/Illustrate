using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;
using System.IO;

namespace Illustrate.Controllers
{
    public class GalleriesController : Controller
    {
        protected IActionResult CustomView(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View("Galleries");
        }

        public IActionResult Index() => CustomView("Galleries");
    }
        public class BaseController : Controller
    {
        public IActionResult Index() => GalleryView();
        public IActionResult Gallery(string viewName) => GalleryView(viewName);
        protected IActionResult GalleryView(string viewName = "Gallery")
        {
            ViewData["ViewName"] = viewName;
            return View();
        }
    }
    public class DemoController : BaseController { }
    public class LaserController : BaseController { }

    public class BulldogsController : BaseController { }

    // Add more galleries here: (the controller name should be the same as the gallery folder name... wwwroot/{galleryFolder}/{controllerName}
    //
    // Example:
    // Uncomment the line below to create a "Family" controller, then add a folder named "Family" to your galleryFolder containing folders with images.
    //
    // public class FamilyController : BaseController { }  

}
