using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTT.Backend.API.Contexto;
using NTT.Backend.API.DTO;

namespace NTT.Backend.API.Services
{
    public class ArticuloServicesSQL : IArticuloServices
    {
        private VentasContext _context;
        public ArticuloServicesSQL(VentasContext context)
        {
            _context = context;
        }
        public Articulo Insertar(Articulo articulo)
        {
            _context.Articulo.Add(articulo);
            _context.SaveChanges();
            return articulo;
        }

        public List<Articulo> Listar()
        {
            return (from x in _context.Articulo select x).ToList();
        }

        public Articulo Recuperar(int id)
        {
            return _context.Articulo.FirstOrDefault(x => x.codigo == id);
        }

        public Articulo Update(Articulo articulo)
        {
            _context.Articulo.Update(articulo);
            _context.SaveChanges();
            return articulo;
        }
    }
}
