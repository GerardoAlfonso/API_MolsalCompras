using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using API_ComprasMosal.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.BL.Implement
{
    public class UsuarioImplement : UsuarioDAO
    {
        private readonly ApplicationDBContext context;

        public UsuarioImplement(ApplicationDBContext context)
        {
            this.context = context;
        }
        #region CRUD
        public int Create(Usuario entity)
        {
            entity.FechaCreacion = DateTime.Now;
            entity.Clave = Crypto.Encrypt(entity.Clave);
            entity.Estado = 1;
            entity.UsuarioCreacion = 1;
            entity.UsuarioModificacion = 1;
            context.Usuario.Add(entity);
            context.SaveChanges();
            return entity.idUsuario;
        }

        public void Delete(Usuario entity)
        {
            context.Usuario.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Usuario DBEntity, Usuario entity)
        {
            DBEntity.NombreUsuario = entity.NombreUsuario;
            DBEntity.FechaModificacion = entity.FechaModificacion;
            DBEntity.UsuarioModificacion = entity.UsuarioModificacion;
            context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuario
                .Where(u => u.Estado == 1)
                .ToList();
        }

        public Usuario GetById(long Id)
        {
            return context.Usuario
                .FirstOrDefault(e => e.idUsuario == Id);
        }

        public void Desactivar(long? IdUsuario)
        {
            Usuario usuario = context.Usuario.FirstOrDefault(u => u.idUsuario == IdUsuario);
            usuario.Estado = 2;
            context.SaveChanges();
        }

        public void Activar(long? IdUsuario)
        {
            Usuario usuario = context.Usuario.FirstOrDefault(u => u.idUsuario == IdUsuario);
            usuario.Estado = 1;
            context.SaveChanges();
        }

        public void ActualizarInfo(Usuario entity)
        {
            Usuario user = context.Usuario.Find(entity.idUsuario);
            user.Estado = entity.Estado;
            user.FechaModificacion = entity.FechaModificacion;
            user.UsuarioModificacion = entity.UsuarioModificacion;
            context.SaveChanges();
        }

        #endregion

        public Usuario LogIn(Usuario usuarios)
        {
            Usuario _user = context.Usuario
                .FirstOrDefault(e => e.NombreUsuario == usuarios.NombreUsuario && e.Clave == Crypto.Encrypt(usuarios.Clave) && e.Estado == 1);

            return _user;
        }

        public Usuario getUserInfo(string NombreUsuario)
        {
            return context.Usuario
                .FirstOrDefault(e => e.NombreUsuario == NombreUsuario);
        }
    }
}
