using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agenda.Models
{
    public class Contacto
    {
        [Key]
        public int Idcontacto { get; set; }

        [Required(ErrorMessage = "Debes ingresar un Nombre")]
        public string NombreContacto { get; set; }
        [Required(ErrorMessage = "Debes ingresar un Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Debes ingresar un Apellido Materno")]
        public string ApellidoMaterno { get; set; }
       
        public string sexo { get; set; }
        [Required(ErrorMessage = "Debes ingresar una direccion")]
        public string direccion { get; set; }

        public string Referencia { get; set; }
        [Required(ErrorMessage = "Debes ingresar un telefono")]
        public string telefono { get; set; }
       
    }
}