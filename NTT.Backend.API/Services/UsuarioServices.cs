using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            Usuario usuario = _context.Usuario.Find(request.idusuario);
            usuario.rutaimagen = request.rutaimagen;
            usuario.nombrecompleto = request.nombrecompleto;
            usuario.idtipousuario = request.idtipousuario;
            
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

        public List<Usuario> Listar()
        {
            return _context.Usuario.Include("tipousuario").ToList();
        }

        public List<UsuarioTipousuario> ListarUsuarioConTipo()
        {
            return (from u in _context.Usuario
                    join t in _context.TipoUsuario
                    on u.idtipousuario equals t.idtipousuario
                    select new UsuarioTipousuario
                    {
                        user = u,
                        tipousuario = t
                    }).ToList();
        }

        public UsuarioLoginResponse Login(UsuarioLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public UsuarioObtenerResponse RecuperarPorId(int id)
        {
            Usuario usuario = _context.Usuario.Find(id);
            return new UsuarioObtenerResponse
            {
                idusuario = usuario.idusuario,
                nombrecompleto = usuario.nombrecompleto,
                idtipousuario = usuario.idtipousuario,
                rutaimagen = usuario.rutaimagen
            };
        }

        public Usuario RecuperarPorLogin(string login)
        {
            return _context.Usuario.FirstOrDefault(t => t.login == login);
        }

        public Usuario RecuperarTodoPorId(int id)
        {
            return _context.Usuario.Find(id);
        }
    }
}
