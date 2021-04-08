using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Globalization;
using NuevoInmueblateGenNHibernate.Enumerated.RedSocial;
using NuevoInmueblateGenNHibernate.EN.RedSocial;
using System.ComponentModel.DataAnnotations;

namespace InmueblateWeb.Models
{
    public class Usuario
    {
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Display(Name = "NIF")]
        public string nif { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public string fechaNacimiento { get; set; }

        [Display(Name = "Privacidad ")]
        public TipoPrivacidadEnum privacidad { get; set; }

        [Display(Name = "Gustos ")]
        public GustosEN gustos { get; set; }

        [Display(Name = "Teléfono ")]
        public string telefono { get; set; }

        [Display(Name = "Email ")]
        public string email { get; set; }

        [Display(Name = "Dirección ")]
        public string direccion { get; set; }

        [Display(Name = "Población ")]
        public string poblacion { get; set; }

        [Display(Name = "Código Postal ")]
        public string codigoPostal { get; set; }

        [Display(Name = "País ")]
        public string pais { get; set; }

        [Display(Name = "Contraseña ")]
        public String password { get; set; }

    }
}