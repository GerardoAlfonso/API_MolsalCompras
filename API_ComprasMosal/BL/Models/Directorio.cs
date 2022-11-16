using System;
using System.ComponentModel.DataAnnotations;

namespace API_Delivery.BL.Models
{
    public class Directorio
    {
        [Key]
        public int idDirectorio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string DUI { get; set; }
        public string Email { get; set; }
        public int Estado { get; set; }
    }
}
