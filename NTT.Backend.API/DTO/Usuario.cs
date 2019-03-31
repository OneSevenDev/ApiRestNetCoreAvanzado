using System.ComponentModel.DataAnnotations;

namespace NTT.Backend.API.DTO
{
    public class Usuario
    {
        [Key]
        public int idusuario { get; set; }
        public string login { get; set; }
        public byte[] clave { get; set; }
        public string nombrecompleto { get; set; }
        public string rutaimagen { get; set; }
        public int idtipousuario { get; set; }
        public TipoUsuario tipousuario { get; set; }
    }
}
