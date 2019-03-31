using System.ComponentModel.DataAnnotations;

namespace NTT.Backend.API.DTO
{
    public class TipoUsuario
    {
        [Key]
        public int idtiposuario { get; set; }
        public string nombre { get; set; }
    }
}
