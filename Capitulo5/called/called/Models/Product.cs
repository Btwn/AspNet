using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace called.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string NameId { get; set; }
        public string Descripcion { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get;  }
    }
}
