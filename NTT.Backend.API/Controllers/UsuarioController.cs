using Microsoft.AspNetCore.Mvc;
using NTT.Backend.API.Services;
using NTT.Backend.API.Transport.Request;
using NTT.Backend.API.Transport.Response;
using System;
using System.Linq;

namespace NTT.Backend.API.Controllers
{
    public class UsuarioController : ApiBase
    {
        private readonly IUsuarioServices _usuarioServices;
        private ITipoUsuarioServices _tipoUsuarioServices;

        public UsuarioController(
            IUsuarioServices usuarioServices,
            ITipoUsuarioServices tipoUsuarioServices
            )
        {
            this._usuarioServices = usuarioServices;
            this._tipoUsuarioServices = tipoUsuarioServices;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok((from u in _usuarioServices.Listar()
                       select new UsuarioListResponse
                       {
                           idusuario = u.idusuario,
                           login = u.login,
                           nombrecompleto = u.nombrecompleto,
                           nombretipousuario = u.tipousuario.nombre,
                           idtipousuario = u.idtipousuario
                       }).ToList());
        }

        [HttpGet]
        public IActionResult ListarConTipo()
        {
            return Ok(_usuarioServices.ListarUsuarioConTipo());
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

        [HttpPost]
        public IActionResult Actualizar([FromBody] UsuarioActualizarRequest request)
        {
            if (request.idtipousuario <= 0)
            {
                return BadRequest("Debe enviar el id del usuario");
            }
            //if (String.IsNullOrEmpty(request.clave))
            //{
            //    return BadRequest("Debe enviar la clave");
            //}
            return Ok(_usuarioServices.Actualizar(request));
        }

        [HttpGet]
        public IActionResult Obtener(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Debe enviar el id del usuario");
            }
            return Ok(_usuarioServices.RecuperarPorId(id));
        }

        [HttpGet]
        public IActionResult ListarTipoUsuario()
        {
            return Ok(_tipoUsuarioServices.Listar());
        }
    }
}
