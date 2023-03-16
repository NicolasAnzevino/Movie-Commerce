using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data;

namespace MAP
{
    public class MAP_Pelicula
    {
        DAL_Pelicula DAL_Pelicula;
        public MAP_Pelicula()
        {
            DAL_Pelicula = new DAL_Pelicula();
        }

        public List<Genero> Ver_Generos()
        {
            List<Genero> LG = new List<Genero>();

            DataTable DT = DAL_Pelicula.Ver_Generos();

            foreach (DataRow dataRow in DT.Rows)
            {
                LG.Add(new Genero(dataRow.Field<int>(0), dataRow.Field<string>(1)));
            }

            return LG;
        }

        public int Insertar_Pelicula_Temporal()
        {
            return DAL_Pelicula.Insertar_Pelicula_Temporal();
        }

        public void Agregar_Pelicula(Pelicula pPelicula)
        {
            DAL_Pelicula.Agregar_Pelicula(pPelicula);

            List<Genero> GenerosCompletos = new List<Genero>();
            DataTable DT = new DataTable();

            foreach (Genero genero in pPelicula.Generos)
            {
                DataRow dataRow = DAL_Pelicula.Obtener_Genero_con_ID(genero.Nombre);
                DT = dataRow.Table.Clone();
                DT.ImportRow(dataRow);
            }

            foreach (DataRow DR in DT.Rows)
            {
                GenerosCompletos.Add(new Genero(DR.Field<int>(0), DR.Field<string>(1)));
            }

            pPelicula.Generos = GenerosCompletos;

            foreach (Genero genero in pPelicula.Generos)
            {
                DAL_Pelicula.Insertar_Relacion_Genero_Pelicula(genero, pPelicula);
            }
        }

        public Pelicula Obtener_Pelicula(int pID)
        {
            DataTable DTPelicula = DAL_Pelicula.Obtener_Pelicula(pID);
            DataTable DTGenero = DAL_Pelicula.Obtener_Generos_de_Pelicula(pID);

            Pelicula P = new Pelicula(DTPelicula.Rows[0].Field<int>(0), DTPelicula.Rows[0].Field<string>(1), DTPelicula.Rows[0].Field<string>(2), DTPelicula.Rows[0].Field<decimal>(3), DTPelicula.Rows[0].Field<byte[]>(4), DTPelicula.Rows[0].Field<bool>(5));

            foreach (DataRow DR in DTGenero.Rows)
            {
                P.Generos.Add(new Genero(DR.Field<int>(0), DR.Field<string>(1)));
            }

            return P;
        }

        public void Eliminar_Pelicula(Pelicula pPelicula)
        {
            DAL_Pelicula.Eliminar_Pelicula(pPelicula);
        }

        public void Modificar_Pelicula(Pelicula pPelicula, int pCambiaImagen)
        {
            //Explicacion: 0 ES NO CAMBIA IMAGEN, QUEDA LA QUE YA TIENE, 1 CAMBIA IMAGEN.

            List<Genero> GenerosCompletos = new List<Genero>();
            DataTable DT = new DataTable();
            DataRow DRFake = DAL_Pelicula.Obtener_Genero_con_ID("Aventura");

            DT = DRFake.Table.Clone(); //Le damos la estructura de la tabla

            DAL_Pelicula.Eliminar_Generos_de_Pelicula(pPelicula);
            
            foreach (Genero genero in pPelicula.Generos) //Le agregamos las filas
            {
                DT.ImportRow(DAL_Pelicula.Obtener_Genero_con_ID(genero.Nombre));
            }

            foreach (DataRow DR in DT.Rows)
            {
                GenerosCompletos.Add(new Genero(DR.Field<int>(0), DR.Field<string>(1)));
            }

            pPelicula.Generos = GenerosCompletos;

            foreach (Genero genero in pPelicula.Generos)
            {
                DAL_Pelicula.Insertar_Relacion_Genero_Pelicula(genero, pPelicula);
            }

            if (pCambiaImagen == 0) //NO CAMBIA
            {
                DAL_Pelicula.Modificar_Pelicula_No_Cambia_Imagen(pPelicula);
            }
            else if (pCambiaImagen == 1)
            {
                DAL_Pelicula.Modificar_Pelicula_Cambia_Imagen(pPelicula);
            }
        }

        public List<Pelicula> Ver_Peliculas()
        {
            List<Pelicula> LP = new List<Pelicula>();
            DataTable DTPeliculas = DAL_Pelicula.Ver_Peliculas();

            foreach (DataRow DR in DTPeliculas.Rows)
            {
                LP.Add(new Pelicula(DR.Field<int>(0), DR.Field<string>(1), DR.Field<string>(2), DR.Field<decimal>(3), DR.Field<byte[]>(4), DR.Field<bool>(5)));
            }

            return LP;
        }
    }
}
