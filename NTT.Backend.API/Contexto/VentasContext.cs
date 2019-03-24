using Microsoft.EntityFrameworkCore;
using NTT.Backend.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Contexto
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Articulo> Articulo { get; set; }
    }
}
