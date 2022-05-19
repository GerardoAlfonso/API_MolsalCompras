using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class Proveedor
    {
        [Key]
        public int? idProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public string? NIT { get; set; }
        public string? Telefono { get; set; }
        public int? Estado { get; set; }
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
