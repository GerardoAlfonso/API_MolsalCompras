using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Models
{
    public class Compras
    {
        public int idFactura { get; set; }
        public int idProveedor { get; set; }
        public string Correlativo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int idProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal CostoUnitario { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }

        public int UsuarioCreacion { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }



}
}
