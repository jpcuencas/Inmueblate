using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Globalization;

namespace InmueblateWeb.Models
{
    public class Valoracion
    {
        [Required(ErrorMessage="Por favor, introduzca una descripción.")]
        [Display(Name = "Comentario")]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 10, ErrorMessage = "Sólo se admiten valoraciones entre 0 y 10")]
        [DataType(dataType: DataType.Currency)]
        [Display(Prompt = "Valoración para tu compañero.", Description = "Valora a tu compañero", Name = "Valoración")]
        public float valora {get; set;}
    }
}