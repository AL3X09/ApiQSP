using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiQSP.Models
{
    public class UsuarioModel
    {
    }

    //
    public class IngresoUsuarioModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

    public class RegistroUsuarioModel
    {
        [Required]
        [Display(Name = "Codigo Prestador")]
        public string CodPrestador { get; set; }

        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [EmailAddress]
        [Display(Name = "Confirmar Correo electrónico*")]
        [Compare("Email", ErrorMessage = "El correro y el correo de confirmación no coinciden.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña*")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de contraseña no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Razon social")]
        public string RazonSocial { get; set; }

        public string Telefono { get; set; }

    }

}