using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pelicula
    {
        public Pelicula()
        {
            Generos = new List<Genero>();
        }

        public Pelicula(int pCodigo, string pNombre, string pDescripcion, decimal pPrecio, byte[] pImagen, bool pPoseeImagen)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Precio = pPrecio;
            Imagen = pImagen;
            PoseeImagen = pPoseeImagen;

            Generos = new List<Genero>();
        }

        public Pelicula(int pCodigo, string pNombre, decimal pPrecio)
        {
            Codigo = pCodigo;
            Nombre = pNombre;
            Precio = pPrecio;

            Generos = new List<Genero>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool PoseeImagen { get; set; } //0 No, 1 Sí
        public byte[] Imagen { get; set; }

        public List<Genero> Generos { get; set; }
    }
}
