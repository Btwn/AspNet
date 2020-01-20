using Microsoft.AspNetCore.Mvc;
using System;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("MyView", new string[] { "Apple", "Orange", "Pear" });

        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Hello World!";
        //    ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
        //    return View("DebugData");
        //}

        public ViewResult List() => View();
    }
}
