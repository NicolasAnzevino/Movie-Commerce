using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public Venta(int pCodigo, DateTime pFecha, decimal pTotal, Usuario pUsuario)
        {
            Codigo = pCodigo;
            Fecha = pFecha;
            Total = pTotal;
            Usuario = pUsuario;

            Peliculas = new List<Pelicula>();
        }

        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<Pelicula> Peliculas { get; set; }
        public Usuario Usuario { get; set; }

    }
}
