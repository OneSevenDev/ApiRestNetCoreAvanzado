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
        Usuario RecuperarPorId(int id);
        Usuario RecuperarPorLogin(string login);
        UsuarioLoginResponse Login(UsuarioLoginRequest request);
        UsuarioInsertarResponse Insertar(UsuarioInsertarRequest requeset);
        UsuarioActualizarResponse Actualizar(UsuarioActualizarRequest requeset);
    }
}
