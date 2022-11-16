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
    public class ArticuloController : ControllerBase
    {
        private readonly ArticuloDAO articuloDAO;
        public ArticuloController(ArticuloDAO articuloDAO)
        {
            this.articuloDAO = articuloDAO;
        }

        [HttpGet]
        [Route("GetArticulo")]
        public IActionResult GetArticulo()
        {
            List<Articulo> Articulo = new List<Articulo>();
            try
            {
                Articulo = articuloDAO.GetAllActive();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateArticulo")]
        public IActionResult UpdateArticulo([FromBody] Articulo dir)
        {
            //Articulo directorio = directorioDAO.GetById(dir.idDirectorio);
            try
            {
                //if (directorio == null)
                //{
                //    BadRequestDTO badRequestDTO = new BadRequestDTO();
                //    badRequestDTO.message = "No se encontro el directorio";
                //    return BadRequest(badRequestDTO);

                //}
                //else
                //{
                //    //directorioDAO.Update(directorio, dir);
                return Ok();
                //}

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
        public IActionResult CreateDirectorio([FromBody] Articulo dir)
        {
            try
            {
                //int id = directorioDAO.Create(dir);
                return Ok();

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
        public IActionResult DeleteDirectorio([FromBody] Articulo dir)
        {
            try
            {
                //directorioDAO.Delete(dir);
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
