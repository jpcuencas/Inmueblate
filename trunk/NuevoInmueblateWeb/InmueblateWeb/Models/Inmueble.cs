using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InmueblateWeb.Models
{
    public class Inmueble
    {
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "Metros Cuadrados")]
        public int MetrosCuadrados { get; set; }

        [Display(Name = "Precio")]
        public float Precio { get; set; }

        [Display(Name = "Alquiler")]
        public bool Alquiler { get; set; }

        [Display(Name = "Latitud ")]
        public float Latitud { get; set; }

        [Display(Name = "Longitud ")]
        public float Longitud { get; set; }

        [Display(Name = "Categoria ")]
        public string Categoria { get; set; }

    }
}