using API_Delivery.BL.DAO;
using API_Delivery.BL.DTO.Response;
using API_Delivery.BL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Delivery.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    public class DirectorioController : ControllerBase
    {
        private readonly DirectorioDAO directorioDAO;

        public DirectorioController(DirectorioDAO directorioDAO)
        {
            this.directorioDAO = directorioDAO;
        }

        [HttpGet]
        [Route("GetDirectorios")]
        public IActionResult GetDirectorios()
        {
            List<Directorio> directorios = new List<Directorio>();
            try
            {
                directorios = directorioDAO.GetAllActive();
                return Ok(directorios);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateDirectorio")]
        public IActionResult UpdateDirectorio([FromBody] Directorio dir)
        {
            Directorio directorio = directorioDAO.GetById(dir.idDirectorio);
            try
            {
                if (directorio == null)
                {
                    BadRequestDTO badRequestDTO = new BadRequestDTO();
                    badRequestDTO.message = "No se encontro el directorio";
                    return BadRequest(badRequestDTO);
                    
                }
                else
                {
                    directorioDAO.Update(directorio, dir);
                    return Ok();
                }
                
            }
            catch (Exception ex)
            {
                BadRequestDTO badRequestDTO = new BadRequestDTO();
                badRequestDTO.message = "Internal Server Error... " + ex.ToString().Substring(1, 100);
                return StatusCode(StatusCodes.Status500InternalServerError, badRequestDTO);
            }
        }

        [HttpPost]
        [Route("CreateDirectorio")]
        public IActionResult CreateDirectorio([FromBody] Directorio dir)
        {
            try
            {
                int id = directorioDAO.Create(dir);
                return Ok(id);

            }
            catch (Exception ex)
            {
                BadRequestDTO badRequestDTO = new BadRequestDTO();
                badRequestDTO.message = "Internal Server Error... " + ex.ToString().Substring(1, 100);
                return StatusCode(StatusCodes.Status500InternalServerError, badRequestDTO);
            }
        }

        [HttpPost]
        [Route("DeleteDirectorio")]
        public IActionResult DeleteDirectorio([FromBody] Directorio dir)
        {
            try
            {
                directorioDAO.Delete(dir);
                return Ok();
            }
            catch (Exception ex)
            {
                BadRequestDTO badRequestDTO = new BadRequestDTO();
                badRequestDTO.message = "Internal Server Error... " + ex.ToString().Substring(1, 100);
                return StatusCode(StatusCodes.Status500InternalServerError, badRequestDTO);
            }
        }
    }
}
