    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    [Table("Vw_DetalleCompra")]
    public class Vw_DetalleCompra
    {
        [ForeignKey("idFactura")]
        public int? idFactura { get; set; }
        public string? Producto { get; set; }
        public int? Cantidad { get; set; }
        public double? PrecioVenta { get; set; }
        public double? CostoUnitario { get; set; }

    }
}
