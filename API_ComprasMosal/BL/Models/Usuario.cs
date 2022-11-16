using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    //[Table("Usuario", Schema = "Auth")]
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public int idDirectorio { get; set; }
        public string nombreUsuario { get; set; }
        public string clave { get; set; }
        public int Estado { get; set; }


    }
}
