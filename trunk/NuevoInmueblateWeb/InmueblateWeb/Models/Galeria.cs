using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Models
{
    public class Galeria
    {
        [Required(ErrorMessage = "Por favor, introduzca una nombre.")]
        [Display(Name = "Nueva galeria")]
        public string nombre { get; set; }

        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}