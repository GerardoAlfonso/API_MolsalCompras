using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class DetalleFactura
    {
        [Key]
        public int? idDetalle { get; set; }
        public int? idFactura { get; set; }
        public int? idProducto { get; set; }
        public int? Cantidad { get; set; }
        public double? PrecioVenta { get; set; }
        public double? CostoUnitario { get; set; }
        public int? UsuarioCreacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
