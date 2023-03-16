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
    public class MAP_Venta
    {
        DAL_Venta DAL_Venta;
        public MAP_Venta()
        {
            DAL_Venta = new DAL_Venta();
        }

        public void Agregar_Venta(Usuario pUsuario)
        {
            DAL_Venta.Agregar_Venta(pUsuario);
        }

        public int Obtener_ID_Venta(Usuario pUsuario)
        {
            return DAL_Venta.Obtener_ID_Venta(pUsuario);
        }

        public void Agregar_Venta_Detalle(int pID, Pelicula pPelicula, Usuario pUsuario)
        {
            DAL_Venta.Agregar_Venta_Detalle(pID, pPelicula, pUsuario);
        }

        public void Limpiar_Carrito_Compra(Usuario pUsuario)
        {
            DAL_Venta.Limpiar_Carrito_Compra(pUsuario);
        }

        public List<Pelicula> Obtener_Peliculas_de_Carrito(Usuario pUsuario)
        {
            List<Pelicula> LP = new List<Pelicula>();
            DataTable DT = new DataTable();
            DT = DAL_Venta.Obtener_Peliculas_de_Carrito(pUsuario);

            foreach (DataRow dr in DT.Rows)
            {
                LP.Add(new Pelicula(dr.Field<int>(0), dr.Field<string>(1), dr.Field<decimal>(2)));
            }

            return LP;
        }

        public int Obtener_Cant_Peliculas_Carrito(Usuario pUsuario)
        {
            return DAL_Venta.Obtener_Cant_Peliculas_Carrito(pUsuario);
        }


    }
}
