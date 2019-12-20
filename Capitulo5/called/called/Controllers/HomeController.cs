using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using called.Models;

namespace called.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product[] array = {
new Product {NameId = "Kayak", Price = 275M},
new Product {NameId = "Lifejacket", Price = 48.95M},
new Product {NameId = "Soccer ball", Price = 19.50M},
new Product {NameId = "Corner flag", Price = 34.95M}
};
            return View(array);
        }
    }
}