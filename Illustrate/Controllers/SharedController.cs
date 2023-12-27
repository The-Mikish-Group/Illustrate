using Microsoft.AspNetCore.Mvc;
using Illustrate.Models;
using System.Diagnostics;

namespace Illustrate.Controllers
{
    public class GalleriesController : Controller
    {
        public IActionResult Index() => View("Galleries");
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
    public class APController : BaseController { }
    public class BCController : BaseController { }
    public class MJRController : BaseController { }
    public class MVController : BaseController { }  
    public class LaserController : BaseController { }    
}
