using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acceso.Models
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string pass { get; set; }
        public string rol { get; set; }
        public bool ac { get; set; }
    }
}