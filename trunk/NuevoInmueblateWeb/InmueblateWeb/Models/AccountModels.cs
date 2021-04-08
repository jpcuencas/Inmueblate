using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace InmueblateWeb.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser como mínimo de {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma la nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Por favor, introduzca su dirección de correo electrónico")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Dirección de correo electrónico (Información obligatoria)")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Por favor, introduzca una dirección de correo electrónico valida")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser como mínimo de {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña (Información obligatoria)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nombre (Información obligatoria)")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Display(Name= "Nif")]
        public string Nif {get; set; }

        [Display(Name= "Fecha de nacimiento")]
        public string FechaNacimiento {get; set; }

        [Display(Name= "Telefono")]
        public string Telefono {get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name= "Población")]
        public string Poblacion {get; set; }

        [Display(Name= "Código postal")]
        public string CodigoPostal {get; set; }

        [Display(Name= "País")]
        public string Pais {get; set; }

        [Display(Name= "Cif")]
        public string Cif {get; set; }

        [Display(Name= "Descripción")]
        public string Descripcion {get; set; }
    }
}
