using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class DetalleFacturaImplement : DetalleFacturaDAO
    {
        private readonly ApplicationDBContext context;

        public DetalleFacturaImplement(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Create(DetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetalleFactura> GetAll()
        {
            throw new NotImplementedException();
        }

        public DetalleFactura GetById(long Id)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<DetalleFactura> GetDetalleFactura(long Id)
        {
            return context.DetalleFactura.Where(e => e.idFactura == Id).ToList();
        }

        public void Update(DetalleFactura DBEntity, DetalleFactura entity)
        {
            throw new NotImplementedException();
        }
    }
}
