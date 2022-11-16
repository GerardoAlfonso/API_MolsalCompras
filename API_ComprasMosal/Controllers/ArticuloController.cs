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
        [Route("GetArticulos")]
        public IActionResult GetArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            try
            {
                articulos = articuloDAO.GetAllActive();
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error: " + ex.Message);
            }
        }
        [HttpPost]
        [Route("UpdateArticulo")]
        public IActionResult UpdateArticulo([FromBody] Articulo art)
        {
            Articulo articulo = articuloDAO.GetById(art.idArticulo);
            try
            {
                if (articulo == null)
                {
                    BadRequestDTO badRequestDTO = new BadRequestDTO();
                    badRequestDTO.message = "No se encontro el directorio";
                    return BadRequest(badRequestDTO);
                }
                else
                {
                    articuloDAO.Update(articulo, art);
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
        [Route("CreateArticulo")]
        public IActionResult CreateArticulo([FromBody] Articulo dir)
        {
            try
            {
                int id = articuloDAO.Create(dir);
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
        [Route("DeleteArticulo")]
        public IActionResult DeleteArticulo([FromBody] Articulo dir)
        {
            try
            {
                articuloDAO.Delete(dir);
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
