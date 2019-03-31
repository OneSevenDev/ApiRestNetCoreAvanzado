using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Transport.Request
{
    public class UsuarioActualizarRequest
    {
        public int idusuario { get; set; }
        public string login { get; set; }
        public string clave { get; set; }
        public string nombrecompleto { get; set; }
        public int idtipousuario { get; set; }
    }
}
