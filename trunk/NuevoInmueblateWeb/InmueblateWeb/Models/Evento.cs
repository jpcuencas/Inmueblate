using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Models
{
    public class Evento
    {
        [Required(ErrorMessage = "Por favor, introduzca un nombre.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca una descripcion.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        public string Fecha { get; set; }

        [Display(Name = "Geolocalizacion ")]
        public GeolocalizacionEN Geolocalizacion { get; set; }
       
        [Display(Name = "Latitud ")]
        public float Latitud { get; set; }
        
        [Display(Name = "Longitud ")]
        public float Longitud { get; set; }

        [Display(Name = "Categoria ")]
        public string Categoria { get; set; }

        [Display(Name = "Inmobiliaria ")]
        public InmobiliariaEN Inmobiliaria { get; set; }

    }
}