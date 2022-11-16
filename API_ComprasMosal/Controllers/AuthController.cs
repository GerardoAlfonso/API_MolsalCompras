using API_Delivery.BL.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using API_ComprasMosal.BL.Models;
using API_Delivery.BL.DAO;
using API_Delivery.BL.DTO.Response;
using Microsoft.AspNetCore.Http;
using API_Delivery.BL.DTO.Request;
using API_Delivery.BL.Models;

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
        public IActionResult LogIn([FromBody] LogInDTO login)
        {
            try
            {
                Directorio directorio = usuarioDAO.getUserInfoDir(login.email);
                if (directorio != null)
                {
                    Usuario _loggedUser = usuarioDAO.LogIn(login);
                    if (_loggedUser != null)
                    {
                        //Se valida que el usuario esté activo
                        if (_loggedUser.Estado == 1)
                        {
                            LoginResponseDTO dataDTO = new LoginResponseDTO();
                            dataDTO.nombre = directorio.Nombre + " " + directorio.Apellido;
                            dataDTO.idUsuario = _loggedUser.idUsuario;
                            dataDTO.nombreUsuario = _loggedUser.nombreUsuario;

                            return Ok(dataDTO);
                        }
                        else
                        {
                            BadRequestDTO badRequestDTO = new BadRequestDTO();
                            badRequestDTO.message = "El usuario se encuentra inactivo";
                            return BadRequest(badRequestDTO);
                        }  
                    }
                    else
                    {
                        BadRequestDTO badRequestDTO = new BadRequestDTO();
                        badRequestDTO.message = "Datos incorrectos, revise usuario y contraseña.";
                        return BadRequest(badRequestDTO);
                    }
                }
                else
                {
                    BadRequestDTO badRequestDTO = new BadRequestDTO();
                    badRequestDTO.message = "No se encontro el usuario";
                    return BadRequest(badRequestDTO);
                }
            }
            catch(Exception ex)
            {
                BadRequestDTO badRequestDTO = new BadRequestDTO();
                badRequestDTO.message = "Internal Server Error... " + ex.ToString().Substring(1,100);
                return StatusCode(StatusCodes.Status500InternalServerError, badRequestDTO);
            }
        }


        //// registro de usuarios
        //[Route("CheckIn")]
        //public IActionResult CheckIn([FromBody] RegistroDTO registro)
        //{
        //    LogInDTO log = new LogInDTO();
        //    Usuario userInfo = usuarioDAO.getUserInfo(registro.NombreUsuario);
        //    Usuario user = new Usuario();

        //    try
        //    {
        //        if (userInfo != null)
        //        {
        //            log.Message = "El nombre de usuario ya esta registrado en el sistema";
        //            log.Status = 0;
        //            return Ok(log);
        //        }

        //        //Registrar usuario
        //        user.nombreUsuario = registro.NombreUsuario;
        //        user.clave = registro.Clave;
        //        user.idUsuario = usuarioDAO.Create(user);

        //        //JWT
        //        //log.Token = JWT.create_token(user.NombreUsuario);
        //        log.NombreUsuario = user.nombreUsuario;
        //        log.Status = 1;
        //        return Ok(log);
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Status = 0;
        //        log.Message = ex.Message;
        //        return BadRequest(log);
        //    }
        //}

    }
}
