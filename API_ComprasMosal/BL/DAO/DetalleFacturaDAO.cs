using API_ComprasMosal.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.DAO
{
    public interface DetalleFacturaDAO : CRUD<DetalleFactura>
    {
        IEnumerable<DetalleFactura> GetDetalleFactura(long Id);
    }
}
