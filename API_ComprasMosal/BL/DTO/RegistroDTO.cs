using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.DTO
{
    public class RegistroDTO
    {

        [Required(ErrorMessage = "El usuario no puede estar vacío.")]
        public string NombreUsuario { get; set; }

        //[Required(ErrorMessage = "El correo no puede estar vacío.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no debe estar vacía.")]
        public string Clave { get; set; }

        [Compare("Clave", ErrorMessage = "Las contraseñas no coinciden.")]
        [NotMapped]
        public string Confirm_Clave { get; set; }

    }
}
