using Microsoft.AspNetCore.Mvc;
using NTT.Backend.API.DTO;
using NTT.Backend.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Controllers
{
    public class ArticuloController : ApiBase
    {
        private IArticuloServices _articuloServices;
        public ArticuloController(IArticuloServices articuloServices)
        {
            _articuloServices = articuloServices;
        }

        [HttpGet]
        public string Saludar(string nombre = "Juana")
        {
            return "Hola mundo: " + nombre;
        }

        [HttpGet]
        public List<Articulo> Listar()
        {
            List<Articulo> lista = _articuloServices.Listar();
            return lista;
        }

        [HttpGet]
        public IActionResult Recuperar(int id)
        {
            Articulo articulo = _articuloServices.Recuperar(id);
            if (articulo == null)
            {
                return BadRequest("No se encuentra el articulo");
            }
            return Ok(articulo);
        }

        [HttpPost]
        public IActionResult Insertar ([FromBody] Articulo articulo)
        {
            if (string.IsNullOrEmpty(articulo.nombre))
            {
                return BadRequest("El nombre no puede ser vacio");
            }
            return Ok(_articuloServices.Insertar(articulo));
        }
    }
}
