using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using c4app.Models;
using System;
using System.Linq;

namespace c4app.Controllers
{
    public class HomeController : Controller
    {
       
 public ViewResult Index()
        {
            var products = new[] {
                 new { Name = "Kayak", Price = 275M },
                 new { Name = "Lifejacket", Price = 48.95M },
                 new { Name = "Soccer ball", Price = 19.50M },
                 new { Name = "Corner flag", Price = 34.95M }
 };
            return View(products.Select(p =>
            $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }


    /*
          public class HomeController : Controller
          {
              public ViewResult Index()
              {
                  var products = new[] {
                   new { Name = "Kayak", Price = 275M },
                   new { Name = "Lifejacket", Price = 48.95M },
                   new { Name = "Soccer ball", Price = 19.50M },
                   new { Name = "Corner flag", Price = 34.95M }
                   };
              return View(products.Select(p => p.GetType().Name));
          }
          }
          */
}
    /*
    bool FilterByPrice(Product p)
    {
        return (p?.Price ?? 0) >= 20;
    }
    public ViewResult Index()
    {
        Product[] productArray = {

         new Product {Name = "Kayak", Price = 275M},
         new Product {Name = "Lifejacket", Price = 48.95M},
         new Product {Name = "Soccer ball", Price = 19.50M},
         new Product {Name = "Corner flag", Price = 34.95M}
         };
                    Func<Product, bool> nameFilter = delegate (Product prod) {
            return prod?.Name?[0] == 'S';
        };
        decimal priceFilterTotal = productArray
        .Filter(FilterByPrice)
        .TotalPrices();
        decimal nameFilterTotal = productArray
        .Filter(nameFilter)
        .TotalPrices();
        return View("Index", new string[] {
     $"Price Total: {priceFilterTotal:C2}",
     $"Name Total: {nameFilterTotal:C2}" });
    }
    */


        /*
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }
        public ViewResult Index()
        {
            Product[] productArray = {
             new Product {Name = "Kayak", Price = 275M},
             new Product {Name = "Lifejacket", Price = 48.95M},
             new Product {Name = "Soccer ball", Price = 19.50M},
             new Product {Name = "Corner flag", Price = 34.95M}
             };
            decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            Func<Product, bool> nameFilter = delegate (Product prod) {
                return prod?.Name?[0] == 'S';
            };
            decimal priceFilterTotal = productArray
            .Filter(FilterByPrice)
            .TotalPrices();
            decimal nameFilterTotal = productArray
            .Filter(nameFilter)
            .TotalPrices();

            return View("Index", new string[] {
                 $"Price Total: {priceFilterTotal:C2}",
                 $"Name Total: {nameFilterTotal:C2}" });
        }

    }*/
        /*public class HomeController : Controller
        {
            public ViewResult Index()
            {
                ShoppingCart cart
                = new ShoppingCart { Products = Product.GetProducts() };
                Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M}
     };
                decimal cartTotal = cart.TotalPrices();
                decimal arrayTotal = productArray.TotalPrices();
                return View("Index", new string[] {
                $"Cart Total: {cartTotal:C2}",
                $"Array Total: {arrayTotal:C2}" });
            }
        }*/


/*----------------------------------------------------------------------------
 *ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
 decimal cartTotal = cart.TotalPrices();



 Product[] productArray = {
  new Product {Name = "Kayak", Price = 275M},
  new Product {Name = "Lifejacket", Price = 48.95M}
  };
 cartTotal = cart.TotalPrices();
 decimal arrayTotal = productArray.TotalPrices();
 return View("Index", new string[] {
  $"Cart Total: {cartTotal:C2}",
  $"Array Total: {arrayTotal:C2}" });



 object[] data = new object[] { 275M, 29.95M,
                     "apple", "orange", 100, 10 };
 decimal total = 0;
 for (int i = 0; i < data.Length; i++)
 {
     switch (data[i])
     {
         case decimal decimalValue:
             total += decimalValue;
             break;
         case int intValue when intValue > 50:
             total += intValue;
             break;
     }
 }
 return View("Index", new string[] { $"Total: {total:C2}" });
 --------------------------------------------------------------------
     */
//Dictionary<string, Product> products = new Dictionary<string, Product>

//    ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
//    ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
//};
//return View("Index", products.Keys);
//------------------------------------------------
//List<string> results = new List<string>();
//foreach (Product p in Product.GetProducts())
//{
//   string name = p?.Name ?? "<No Name>";
//   decimal? price = p?.Price ?? 0;
//   string relatedName = p?.Related?.Name ?? "<None>";
//   results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
//}
//return View(results);
