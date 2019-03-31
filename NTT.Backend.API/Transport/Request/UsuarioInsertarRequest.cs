using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Transport.Request
{
    public class UsuarioInsertarRequest
    {
        public string login { get; set; }
        public string clave { get; set; }
        public string nombrecompleto { get; set; }
        public string rutaimagen { get; set; }
        public int idtipousuario { get; set; }
    }
}
