using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Transport.Response
{
    public class UsuarioListResponse
    {
        public int idusuario { get; set; }
        public string login { get; set; }
        public string nombrecompleto { get; set; }
        public int idtipousuario { get; set; }
        public string nombretipousuario { get; set; }
    }
}
