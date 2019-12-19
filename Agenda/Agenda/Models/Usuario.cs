using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Usuario
    {

        [Key]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Debes ingresar contraseña")]
        public string pass { get; set; }
        [Required(ErrorMessage = "Debes ingresar un Rol")]
        public string rol { get; set; }
        public bool acc { get; set; }
        
    }
}