using NTT.Backend.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Services
{
    public interface ITipoUsuarioServices
    {
        List<TipoUsuario> Listar();
    }
}
