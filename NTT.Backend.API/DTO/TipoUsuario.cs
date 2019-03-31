using System.ComponentModel.DataAnnotations;

namespace NTT.Backend.API.DTO
{
    public class TipoUsuario
    {
        [Key]
        public int idtipousuario { get; set; }
        public string nombre { get; set; }
    }
}
