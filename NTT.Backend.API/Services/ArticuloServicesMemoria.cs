using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NTT.Backend.API.DTO;

namespace NTT.Backend.API.Services
{
    public class ArticuloServicesMemoria : IArticuloServices
    {
        private List<Articulo> _contexto;
        public ArticuloServicesMemoria()
        {
            _contexto = new List<Articulo>();
            _contexto.Add(new Articulo { codigo = 1, nombre = "Celular", precio = 2400 });
            _contexto.Add(new Articulo { codigo = 1, nombre = "iPhone", precio = 1500 });
            _contexto.Add(new Articulo { codigo = 1, nombre = "Teclado", precio = 25 });
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Articulo Insertar(Articulo articulo)
        {
            return null;
        }

        public List<Articulo> Listar()
        {
            return _contexto;
        }

        public Articulo Recuperar(int id)
        {
            // ambos codigos son los mismos el tiempo de obtimizacion
            Articulo articulo = (from x in _contexto
                                 where x.codigo == id
                                 select x).FirstOrDefault();

            return _contexto.FirstOrDefault(x => x.codigo == id);
        }

        public Articulo Update(Articulo articulo)
        {
            throw new NotImplementedException();
        }
    }
}
