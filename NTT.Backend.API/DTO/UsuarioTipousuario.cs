using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.DTO
{
    public class UsuarioTipousuario
    {
        public Usuario user { get; set; }
        public TipoUsuario tipousuario { get; set; }
    }
}
