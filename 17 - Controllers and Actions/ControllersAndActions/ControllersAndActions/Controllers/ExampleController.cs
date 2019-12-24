using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult Result() => View((object)"Hello World");

        public RedirectToActionResult Redirect() =>
            //RedirectPermanent("/Example/Index");
            RedirectToAction(nameof(Index));

        public JsonResult JsonAction() => Json(new object[] { "Alice", "Bob", "Joe" });

        //public ContentResult ContentAction() => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");
        public ObjectResult ContentAction() => Ok(new string[] { "Alice", "Bob", "Joe" });

        public VirtualFileResult FileVirtual() =>
            File("bootstrap/dist/css/bootstrap.css", "text/css");

        public StatusCodeResult StatusAction() => NotFound();
    }
}
