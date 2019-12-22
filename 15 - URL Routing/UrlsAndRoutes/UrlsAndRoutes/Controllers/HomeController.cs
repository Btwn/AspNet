using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Result", new Result { 
            Controller = nameof(HomeController),
            Action = nameof(Index)
        });

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            };
            //r.Data["Id"] = RouteData.Values["id"];
            r.Data["Id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            r.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 });
            return View("Result", r);
        }
    }
}
