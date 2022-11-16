using API_ComprasMosal.BL.Models;
using API_ComprasMosal.DAL;
using API_Delivery.BL.DAO;
using API_Delivery.BL.DTO.Request;
using API_Delivery.BL.Models;
using System.Collections.Generic;
using System.Linq;

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
            //entity.FechaCreacion = DateTime.Now;
            entity.clave = entity.clave;
            entity.Estado = 1;
            //entity.UsuarioCreacion = 1;
            //entity.UsuarioModificacion = 1;
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
            DBEntity.nombreUsuario = entity.nombreUsuario;
            //DBEntity.FechaModificacion = entity.FechaModificacion;
            //DBEntity.UsuarioModificacion = entity.UsuarioModificacion;
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
            //user.FechaModificacion = entity.FechaModificacion;
            //user.UsuarioModificacion = entity.UsuarioModificacion;
            context.SaveChanges();
        }

        #endregion

        public Usuario? LogIn(LogInDTO usuarios)
        {
            Usuario dto = new Usuario();

            var query =
                from user in context.Usuario
                join dir in context.Directorio on user.idDirectorio equals dir.idDirectorio
                where dir.Email == usuarios.email && user.clave == usuarios.clave
                select new
                {
                    idUsuario = user.idUsuario,
                    nombreUsuario = user.nombreUsuario,
                    nombre = dir.Nombre + " " + dir.Apellido,
                    Estado = user.Estado

                };

            if (query.Count() != 0)
            {
                foreach (var item in query)
                {
                    dto.nombreUsuario = item.nombreUsuario;
                    dto.Estado = item.Estado;
                    dto.idUsuario = item.idUsuario;
                }
                return dto;
            }
            else
            {
                return null;
            }



        }



        public Directorio getUserInfoDir(string email)
        {
            return context.Directorio
                .FirstOrDefault(e => e.Email == email);
        }


        public Directorio getUserInfo(string email)
        {
            return context.Directorio
                .FirstOrDefault(e => e.Email == email);
        }
    }
}
