using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NTT.Backend.API.DTO;
using NTT.Backend.API.Helper;
using NTT.Backend.API.Services;
using NTT.Backend.API.Transport.Request;
using NTT.Backend.API.Transport.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Backend.API.Controllers
{
    public class AuthController : ApiBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public AuthController(IUsuarioServices usuarioServices)
        {
            this._usuarioServices = usuarioServices;
        }
        [HttpPost]
        // [AllowAnonymous]
        public IActionResult Validate([FromBody]UsuarioLoginRequest request)
        {
            Usuario user = _usuarioServices.RecuperarPorLogin(request.login);

            // Mala practica, poner solo un mensaje para ambos casos
            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }
            if (EncriptaHelper.Decrypt(user.clave) != request.clave)
            {
                return BadRequest("La clave no coincide");
            }

            #region Token
            // Generar las claims
            Claim[] claims = new[] {
                new Claim("codigo", user.idtipousuario.ToString()),
                new Claim("login", user.login)
            };
            // Generar SigningCredentials
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PalabraSecreta123"));
            SigningCredentials sec = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: sec
                );
            string texto = new JwtSecurityTokenHandler().WriteToken(token);
            #endregion

            UsuarioLoginResponse response = new UsuarioLoginResponse
            {
                idusuario = user.idusuario,
                rutaimagen = user.rutaimagen,
                token = texto
            };
            return Ok(response);
        }
    }
}
