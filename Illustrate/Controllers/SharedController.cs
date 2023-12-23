using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult GalleryView(string viewName = "Gallery")
        {
            ViewData["ViewName"] = viewName;
            return View();
        }
    }
    public class GalleriesController : BaseController
    {
        public IActionResult Index() => View("Galleries");
    }

    public class APController : BaseController
    {
        public IActionResult Index() => GalleryView();
        public IActionResult Gallery(string viewName) => GalleryView(viewName);
    }

    public class BCController : BaseController
    {
        public IActionResult Index() => GalleryView();
        public IActionResult Gallery(string viewName) => GalleryView(viewName);
    }

    public class MVController : BaseController
    {
        public IActionResult Index() => GalleryView();
        public IActionResult Gallery(string viewName) => GalleryView(viewName);
    }

    public class LaserController : BaseController
    {
        public IActionResult Index() => GalleryView();
        public IActionResult Gallery(string viewName) => GalleryView(viewName);
    }


    

}
