using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NTT.Backend.API.Transport.Request;

namespace NTT.Backend.API.Controllers
{
    public class NotificaController : ApiBase
    {
        private IHubContext<NotificaHub> _hubContext;

        public NotificaController(IHubContext<NotificaHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult EnviarMensaje([FromBody]NotificaRequest request)
        {
            this._hubContext.Clients.All.SendAsync("EnviarClientesTodos", request.message);
            return Ok("Mensaje Enviado");
        }
    }
}
