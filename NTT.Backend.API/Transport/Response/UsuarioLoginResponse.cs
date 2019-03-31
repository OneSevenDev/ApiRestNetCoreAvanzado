using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Transport.Response
{
    public class UsuarioLoginResponse
    {
        public string token { get; set; }
        public int idusuario { get; set; }
        public string rutaimagen { get; set; }
    }
}
