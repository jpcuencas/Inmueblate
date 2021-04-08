using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Globalization;

namespace InmueblateWeb.Models
{
    public class Peticion
    {
        [Required(ErrorMessage = "Por favor, introduzca un título para la petición.")]
        [Display(Name = "Título")]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca un mensaje para la petición.")]
        [DataType(dataType: DataType.Currency)]
        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; }
    }
}