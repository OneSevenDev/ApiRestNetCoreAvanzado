using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTT.Backend.API.Contexto;
using NTT.Backend.API.DTO;

namespace NTT.Backend.API.Services
{
    public class TipoUsuarioServices : ITipoUsuarioServices
    {
        private readonly VentasContext _context;

        public TipoUsuarioServices(VentasContext ventasContext)
        {
            this._context = ventasContext;
        }
        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuario.ToList();
        }
    }
}
