using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class Directorio
    {
        public int idDirectorio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string DUI { get; set; }
        public string Correo { get; set; }
        public int Estado { get; set; }
        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }


    }
}
