using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTT.Backend.API.Contexto;
using NTT.Backend.API.DTO;
using NTT.Backend.API.Helper;
using NTT.Backend.API.Transport.Request;
using NTT.Backend.API.Transport.Response;

namespace NTT.Backend.API.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly VentasContext _context;
        public UsuarioServices(VentasContext context)
        {
            this._context = context;
        }

        public UsuarioActualizarResponse Actualizar(UsuarioActualizarRequest request)
        {
            byte[] clave = EncriptaHelper.EncryptToByte(request.clave);
            Usuario usuario = new Usuario
            {
                idusuario = request.idusuario,
                clave = clave,
                login = request.login,
                nombrecompleto = request.nombrecompleto,
                idtipousuario = request.idtipousuario
            };
            _context.Usuario.Update(usuario);
            _context.SaveChanges();
            return new UsuarioActualizarResponse
            {
                idusuario = usuario.idusuario,
                login = usuario.login
            };
        }

        public UsuarioInsertarResponse Insertar(UsuarioInsertarRequest request)
        {
            byte[] clave = EncriptaHelper.EncryptToByte(request.clave);
            Usuario usuario = new Usuario
            {
                clave = clave,
                login = request.login,
                nombrecompleto = request.nombrecompleto,
                rutaimagen = request.rutaimagen,
                idtipousuario = request.idtipousuario
            };
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return new UsuarioInsertarResponse
            {
                idusuario = usuario.idusuario,
                login = usuario.login
            };
        }

        public UsuarioLoginResponse Login(UsuarioLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Usuario RecuperarPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public Usuario RecuperarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(t => t.login == login);
        }
    }
}
