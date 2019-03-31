using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Transport.Response
{
    public class UsuarioObtenerResponse
    {
        public int idusuario { get; set; }
        public string nombrecompleto { get; set; }
        public string rutaimagen { get; set; }
        public int idtipousuario { get; set; }
    }
}
