using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class Vw_DetalleCompraImplement : Vw_DetalleCompraDAO
    {
        private readonly ApplicationDBContext context;

        public Vw_DetalleCompraImplement(ApplicationDBContext context)
        {
            this.context = context;
        }
        public int Create(Vw_DetalleCompra entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vw_DetalleCompra entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_DetalleCompra> GetAll()
        {
            return context.Vw_DetalleCompra.ToList();
        }

        public Vw_DetalleCompra GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vw_DetalleCompra DBEntity, Vw_DetalleCompra entity)
        {
            throw new NotImplementedException();
        }
    }
}
