using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04LanguajeFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock;
        }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; }


        public static Product[] GetProducts()
        {
            Product kayat = new Product
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 275M
            };

            Product lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Price = 48.95M
            };

            kayat.Related = lifejacket;

            return new Product[] { kayat, lifejacket, null };
        }
    }
}
