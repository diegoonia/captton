using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    public class Registro
    {
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required]
        public string Apellido { get; set; }

        [Display(Name = "Dni")]
        [Required]
        public int Dni { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(25, ErrorMessage = "La contraseña es muy corta o muy larga", MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repita su contraseña")]
        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string PasswordConfirmation { get; set; }
    }

    public class Login
    {
        [Display(Name = "Nombre de usuario")]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Mantener sesion iniciada")]
        public bool RememberMe { get; set; }
    }
}