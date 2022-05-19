using API_ComprasMosal.BL.DAO;
using API_ComprasMosal.BL.DTO;
using API_ComprasMosal.BL.Models;
using API_ComprasMosal.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_ComprasMosal.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    //[Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UsuarioDAO usuarioDAO;
        public AuthController(UsuarioDAO userDAO)
        {
            usuarioDAO = userDAO;
        }

        [Route("Login")]
        public IActionResult LogIn([FromBody] Usuario login)
        {
            LogInDTO log = new LogInDTO();
            try
            {
                Usuario usuario = usuarioDAO.getUserInfo(login.NombreUsuario);
                if (usuario != null)
                {
                    //Se valida que el usuario esté activo
                    if (usuario.Estado == 1)
                    {
                        Usuario _loggedUser = usuarioDAO.LogIn(login);
                        if (_loggedUser != null)
                        {
                            //JWT
                            log.Token = JWT.create_token(_loggedUser.NombreUsuario);
                            log.NombreUsuario = _loggedUser.NombreUsuario;
                            log.Status = 1;
                            return Ok(log);
                        }
                        else
                        {
                            log.Message = "Datos incorrectos, revise usuario y contraseña.";
                            log.Status = 0;
                            return Ok(log);
                        }
                    }
                    else
                    {
                        log.Message = "El usuario se encuentra inactivo";
                        log.Status = 0;
                        return Ok(log);
                    }
                }
                else
                {
                    log.Message = "No se encontro el usuario";
                    log.Status = 0;
                    return Ok(log);
                }
            }
            catch(Exception ex)
            {
                log.Message = ex.Message;
                log.Status = 0;
                return BadRequest(log);
            }
        }


        // registro de usuarios
        [Route("CheckIn")]
        public IActionResult CheckIn([FromBody] RegistroDTO registro)
        {
            LogInDTO log = new LogInDTO();
            Usuario userInfo = usuarioDAO.getUserInfo(registro.NombreUsuario);
            Usuario user = new Usuario();

            try
            {
                if (userInfo != null)
                {
                    log.Message = "El nombre de usuario ya esta registrado en el sistema";
                    log.Status = 0;
                    return Ok(log);
                }

                //Registrar usuario
                user.NombreUsuario = registro.NombreUsuario;
                user.Clave = registro.Clave;
                user.idUsuario = usuarioDAO.Create(user);

                //JWT
                log.Token = JWT.create_token(user.NombreUsuario);
                log.NombreUsuario = user.NombreUsuario;
                log.Status = 1;
                return Ok(log);
            }
            catch(Exception ex)
            {
                log.Status = 0;
                log.Message = ex.Message;
                return BadRequest(log);
            }
        }

    }
}
