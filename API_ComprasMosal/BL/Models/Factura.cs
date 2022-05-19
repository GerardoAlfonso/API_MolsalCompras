using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int? idFactura { get; set; }
        public int? idProveedor { get; set; }
        public string Correlativo { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Total { get; set; }
        public int? Estado { get; set; }
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
