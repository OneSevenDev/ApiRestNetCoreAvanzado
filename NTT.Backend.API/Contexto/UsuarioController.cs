using Microsoft.AspNetCore.Mvc;
using NTT.Backend.API.Controllers;
using NTT.Backend.API.Services;
using NTT.Backend.API.Transport.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Contexto
{
    public class UsuarioController : ApiBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            this._usuarioServices = usuarioServices;

        }
        [HttpPost]
        public IActionResult Insertar([FromBody] UsuarioInsertarRequest request)
        {
            if (String.IsNullOrEmpty(request.clave))
            {
                return BadRequest("Debe enviar la clave");
            }
            return Ok(_usuarioServices.Insertar(request));
        }
    }
}
