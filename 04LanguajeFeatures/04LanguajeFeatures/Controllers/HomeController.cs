using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _04LanguajeFeatures.Models;

namespace _04LanguajeFeatures.Controllers
{
    public class HomeController: Controller
    {
        //public ViewResult Index()
        //{
        //    List<string> results = new List<string>();
        //    foreach (Product p in Product.GetProducts())
        //    {
        //        string name = p?.Name ?? "<No Name>";
        //        decimal? price = p?.Price ?? 0;
        //        string relatedName = p?.Related?.Name ?? "<none>";
        //        string category = p?.Category ?? "<none>";
        //        //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
        //        results.Add($"Name: {name}, Price: {price}, Related: {relatedName}, Category: {category}");
        //    }
        //    return View(results);
        //}

        //       public ViewResult Index()
        //       {
        //           object[] data = new object[] { 275M, 29.95M,
        //"apple", "orange", 100, 10 };
        //           decimal total = 0;
        //           for (int i = 0; i < data.Length; i++)
        //           {
        //               switch (data[i])
        //               {
        //                   case decimal decimalValue:
        //                       total += decimalValue;
        //                       break;
        //                   case int intValue when intValue > 50:
        //                       total += intValue;
        //                       break;
        //               }
        //           }
        //           return View("Index", new string[] { $"Total: {total:C2}" });
        //       }
        public ViewResult Index()
        {
            return View(Product.GetProducts().Select(p => p?.Name));
        }
    }
}
