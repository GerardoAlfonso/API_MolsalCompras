using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class FacturaImplement : FacturaDAO
    {
        private readonly ApplicationDBContext context;

        public FacturaImplement(ApplicationDBContext context)
        {
            this.context = context;
        }

        public int Create(Factura entity)
        {
            entity.idProveedor = 1;
            entity.Fecha = DateTime.Now;
            entity.Estado = 1;
            entity.UsuarioCreacion = 1;
            entity.FechaCreacion = DateTime.Now;

            context.Factura.Add(entity);
            context.SaveChanges();
            return (int)entity.idFactura;
        }

        public void Delete(Factura entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> GetAll()
        {
            return context.Factura.ToList();
        }

        public Factura GetById(long Id)
        {
            return context.Factura.Where(f => f.idProveedor == Id).FirstOrDefault();
        }
        public IEnumerable<string> GetById_2(long Id)
        {
            return (IEnumerable<string>)context.Factura.Where(f => f.idProveedor == Id);
        }

        public void Update(Factura DBEntity, Factura entity)
        {
            throw new NotImplementedException();
        }
    }
}
