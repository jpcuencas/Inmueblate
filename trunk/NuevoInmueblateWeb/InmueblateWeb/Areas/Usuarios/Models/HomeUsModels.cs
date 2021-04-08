using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InmueblateWeb.Areas.Usuarios.Models
{
    public class BuscarInModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Dirección de correo electrónico")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Email { get; set; }

      

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Nif")]
        public string Nif { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Población")]
        public string Poblacion { get; set; }

        [Display(Name = "Código postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Cif")]
        public string Cif { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }

    public class BuscarAmModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Dirección de correo electrónico")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Email { get; set; }



        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Nif")]
        public string Nif { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Población")]
        public string Poblacion { get; set; }

        [Display(Name = "Código postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Cif")]
        public string Cif { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}