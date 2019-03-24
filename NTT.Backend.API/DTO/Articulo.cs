using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.DTO
{
    public class Articulo
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
    }
}
