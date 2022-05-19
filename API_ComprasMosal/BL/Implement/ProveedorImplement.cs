using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class ProveedorImplement : ProveedorDAO
    {
        private readonly ApplicationDBContext context;

        public ProveedorImplement(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Create(Proveedor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Proveedor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proveedor> GetAll()
        {
            return context.Proveedor.ToList();
        }

        public Proveedor GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Proveedor DBEntity, Proveedor entity)
        {
            throw new NotImplementedException();
        }
    }
}
