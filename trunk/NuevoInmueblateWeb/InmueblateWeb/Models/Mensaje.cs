using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NuevoInmueblateGenNHibernate.EN.RedSocial;

namespace InmueblateWeb.Models
{
    public class Mensaje
    {
        [Required(ErrorMessage = "Por favor, introduzca un asunto.")]
        [DataType(DataType.Text)]
        [Display(Name = "Asunto")]
        public string Asunto { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha envio")]
        public DateTime FechaEnvio { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca un mensaje.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Cuerpo")]
        public string Cuerpo { get; set; }

        [Display(Name = "Leido")]
        public bool Leido { get; set; }

        [Display(Name = "Para")]
        public string Receptor { get; set; }

    }
}