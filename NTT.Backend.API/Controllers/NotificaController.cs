using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NTT.Backend.API.DTO;
using NTT.Backend.API.Services;
using NTT.Backend.API.Transport.Request;

namespace NTT.Backend.API.Controllers
{
    public class NotificaController : ApiBase
    {
        private IHubContext<NotificaHub> _hubContext;
        private IArticuloServices _articuloServices;

        public NotificaController(IHubContext<NotificaHub> hubContext, IArticuloServices articuloServices)
        {
            this._hubContext = hubContext;
            this._articuloServices = articuloServices;
        }

        [HttpPost]
        public IActionResult EnviarMensaje([FromBody]NotificaRequest request)
        {
            this._hubContext.Clients.All.SendAsync("EnviarClientesTodos", request.message);
            return Ok("Mensaje Enviado");
        }

        [HttpPut]
        public IActionResult Actualiza([FromBody] Articulo articulo)
        {
            if (articulo.codigo == 0)
            {
                return BadRequest("El codigo no debe ser 0");
            }
            if (string.IsNullOrEmpty(articulo.nombre))
            {
                return BadRequest("El nombre no puede ser vacio");
            }
            Articulo response = _articuloServices.Update(articulo);
            LoadListRealTime();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Insertar([FromBody] Articulo articulo)
        {
            if (string.IsNullOrEmpty(articulo.nombre))
            {
                return BadRequest("El nombre no puede ser vacio");
            }
            Articulo response = _articuloServices.Insertar(articulo);
            LoadListRealTime();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] int codigo)
        {
            if (codigo <= 0)
            {
                return BadRequest("El id es incorrecto");
            }
            bool success = _articuloServices.Delete(codigo);
            LoadListRealTime();
            return Ok(success);
        }

        private void LoadListRealTime()
        {
            List<Articulo> lista = _articuloServices.Listar();
            this._hubContext.Clients.All.SendAsync("ListarArticulosTodos", lista);
        }
    }
}
