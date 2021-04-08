using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Models
{
    public class Entrada
    {
        [Required(ErrorMessage = "Por favor, introduzca una titulo.")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca una contenido.")]
        [Display(Name = "Escribe en tu muro...")]
        public string Cuerpo { get; set; }


        [Display(Name = "Fecha de publicacion")]
        public Nullable<DateTime> FechaPublicacion { get; set; }

        [Display(Name = "Realizada por")]
        public SuperUsuarioEN Creador { get; set; }

        public IList<ElementoMultimediaEN> ElementosMultimedia { get; set; }
       
    }
}