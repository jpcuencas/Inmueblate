using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InmueblateWeb.Models
{
    public class Busqueda
    {

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Dirección de correo electrónico")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name = "Nif")]
        [MaxLength(10)]
        [RegularExpression(@" (([X-Z]{1})([-]?)(\d{7})([-]?)([A-Z]{1}))|((\d{8})([-]?)([A-Z]{1}))", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Nif { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

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
        [MaxLength(10)]
        [RegularExpression(@" (([X-Z]{1})([-]?)(\d{7})([-]?)([A-Z]{1}))|((\d{8})([-]?)([A-Z]{1}))", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Cif { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}