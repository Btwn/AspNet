using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="Por favor introduce un Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
ErrorMessage = "por favor introduce un correo valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor introduce un telefono")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Por Favor elige una opción")]
        public bool? WillAttend { get; set; }
    }
}
