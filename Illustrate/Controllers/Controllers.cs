using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class BaseHomeController : Controller
    {
        protected IActionResult CustomView(string viewName)
        {
            ViewData["ViewName"] = viewName;
            return View();
        }
    }

    public class HomeController : BaseHomeController
    {
        public IActionResult Index() => CustomView("Home");
        public IActionResult Contact() => CustomView("Contact");
        public IActionResult Privacy() => CustomView("Privacy");
        public IActionResult TOS() => CustomView("Terms of Service");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public class BaseController : Controller
    {
        protected IActionResult GalleryView(string viewName = "Gallery")
        {
            ViewData["ViewName"] = viewName;
            return View();
        }
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

    public class GalleriesController : BaseController
    {
        public IActionResult Index() => View("Galleries");
    }
}
