using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MAP;

namespace BLL
{
    public class BLL_Pelicula
    {
        MAP_Pelicula MAP_Pelicula;

        public BLL_Pelicula()
        {
            MAP_Pelicula = new MAP_Pelicula();
        }

        public List<Genero> Ver_Generos()
        {
            return MAP_Pelicula.Ver_Generos();
        }

        public int Insertar_Pelicula_Temporal()
        {
            return MAP_Pelicula.Insertar_Pelicula_Temporal();
        }

        public void Agregar_Pelicula(Pelicula pPelicula)
        {
            MAP_Pelicula.Agregar_Pelicula(pPelicula);
        }

        public Pelicula Obtener_Pelicula(int pID)
        {
            return MAP_Pelicula.Obtener_Pelicula(pID);
        }

        public void Eliminar_Pelicula(Pelicula pPelicula)
        {
            MAP_Pelicula.Eliminar_Pelicula(pPelicula);
        }

        public void Modificar_Pelicula(Pelicula pPelicula, int pCambiaImagen)
        {
            //Explicacion: 0 ES NO CAMBIA IMAGEN, QUEDA LA QUE YA TIENE, 1 CAMBIA IMAGEN.

            MAP_Pelicula.Modificar_Pelicula(pPelicula, pCambiaImagen);
        }

        public List<Pelicula> Ver_Peliculas()
        {
            return MAP_Pelicula.Ver_Peliculas();
        }

    }
}
