using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class Vw_ListadoComprasImplement : Vw_ListadoComprasDAO
    {
        private readonly ApplicationDBContext context;

        public Vw_ListadoComprasImplement(ApplicationDBContext context)
        {
            this.context = context;
        }
        public int Create(Vw_ListadoCompras entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vw_ListadoCompras entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vw_ListadoCompras> GetAll()
        {
            return context.Vw_ListadoCompras.ToList();
        }

        public Vw_ListadoCompras GetById(long Id)
        {
            return context.Vw_ListadoCompras.FirstOrDefault(e => e.idFactura == Id);
        }

        public void Update(Vw_ListadoCompras DBEntity, Vw_ListadoCompras entity)
        {
            throw new NotImplementedException();
        }
    }
}
