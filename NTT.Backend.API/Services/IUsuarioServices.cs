using NTT.Backend.API.DTO;
using NTT.Backend.API.Transport.Request;
using NTT.Backend.API.Transport.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Services
{
    public interface IUsuarioServices
    {
        List<Usuario> Listar();
        List<UsuarioTipousuario> ListarUsuarioConTipo();
        UsuarioObtenerResponse RecuperarPorId(int id);
        Usuario RecuperarTodoPorId(int id);
        Usuario RecuperarPorLogin(string login);
        UsuarioLoginResponse Login(UsuarioLoginRequest request);
        UsuarioInsertarResponse Insertar(UsuarioInsertarRequest requeset);
        UsuarioActualizarResponse Actualizar(UsuarioActualizarRequest requeset);
    }
}
