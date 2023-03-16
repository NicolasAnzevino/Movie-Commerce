using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MAP;

namespace BLL
{
    public class BLL_Venta
    {
        MAP_Venta MAP_Venta;

        public BLL_Venta()
        {
            MAP_Venta = new MAP_Venta();
        }

        public void Realizar_Compra(Usuario pUsuario)
        {
            List<Pelicula> LP = new List<Pelicula>();

            LP = MAP_Venta.Obtener_Peliculas_de_Carrito(pUsuario);

            MAP_Venta.Agregar_Venta(pUsuario);
            int VTAID = MAP_Venta.Obtener_ID_Venta(pUsuario);

            foreach (Pelicula p in LP)
            {
                MAP_Venta.Agregar_Venta_Detalle(VTAID, p, pUsuario);
            }

            MAP_Venta.Limpiar_Carrito_Compra(pUsuario);
        }

        public int Obtener_Cant_Peliculas_Carrito(Usuario pUsuario)
        {
            return MAP_Venta.Obtener_Cant_Peliculas_Carrito(pUsuario);
        }
    }
}
