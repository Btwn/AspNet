using Microsoft.AspNetCore.Mvc;
using System.Text;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("SimpleForm");

        public ViewResult ReceiveForm(string name, string city)
        {
            return View("Result", $"{name} lives in {city}");
        }

        //public IActionResult ReceiveForm(string name, string city)
        //{
        //    return new CustomHtmlResult { Content = $"{name} lives in {city}" };
        //}

        //public void ReceiveForm(string name, string city)
        //{
        //    Response.StatusCode = 200;
        //    Response.ContentType = "text/html";
        //    byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body>");
        //    Response.Body.WriteAsync(content, 0, content.Length);
        //}

        //public ViewResult ReceiveForm(string name, string city) =>
        //View("Result", $"{name} lives in {city}");


        //public ViewResult ReceiveForm()
        //{
        //    var name = Request.Form["name"];
        //    var city = Request.Form["city"];
        //    return View("Result", $"{name} lives in {city}");
        //}
    }
}
