using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Genero
    {
        public Genero()
        {

        }

        public Genero(int pCodigo, string pNombre)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
        }


        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
        public static IComparer<Genero> Orden<T>() where T : IComparer<Genero>, new()
        {
            return new T();
        }

        public class OrdenNombre : IComparer<Genero>
        {
            public int Compare(Genero x, Genero y)
            {
                return string.Compare(x.Nombre, y.Nombre);
            }
        }
    }
}
