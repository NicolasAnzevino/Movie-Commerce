using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class DAL_Venta : SQLKit
    {
        public DAL_Venta() : base()
        {

        }

        public void Agregar_Venta(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                decimal Total = 0;

                Comando.CommandText = "select sum(peli_precio) from pelicula JOIN CarritoCompra ON (Carr_Peli_Codigo = Peli_Codigo AND Carr_User_Codigo = @pID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                Total = (decimal)Comando.ExecuteScalar();

                Comando.CommandText = "INSERT INTO VENTA (Venta_Fecha, Venta_Total, Venta_User_Codigo) VALUES (@pFecha, @pTotal, @pID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pFecha", DateTime.Now.ToShortDateString());
                Comando.Parameters.AddWithValue("pTotal", Total);
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public int Obtener_ID_Venta(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                int ID = 0;

                Comando.CommandText = "SELECT MAX(Venta_Codigo) from Venta where Venta_User_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                ID = (int)Comando.ExecuteScalar();

                Desconectarse();

                return ID;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Agregar_Venta_Detalle(int pID, Pelicula pPelicula, Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "INSERT INTO VENTA_DETALLE (VentaD_Venta_Codigo, VentaD_Peli_Codigo, VentaD_User_Codigo) VALUES (@pVID, @pPID, @pUID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pVID", pID);
                Comando.Parameters.AddWithValue("pPID", pPelicula.Codigo);
                Comando.Parameters.AddWithValue("pUID", pUsuario.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Limpiar_Carrito_Compra(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "DELETE CARRITOCOMPRA WHERE Carr_User_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Peliculas_de_Carrito(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT Peli_Codigo, Peli_Nombre, Peli_Precio FROM Pelicula JOIN CarritoCompra ON (Carr_Peli_Codigo = Peli_Codigo AND Carr_User_Codigo = @pID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@pID", pUsuario.ID);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public int Obtener_Cant_Peliculas_Carrito(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                int ID = 0;

                Comando.CommandText = "SELECT COUNT(Carr_Codigo) FROM CarritoCompra WHERE Carr_user_codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                ID = (int)Comando.ExecuteScalar();

                Desconectarse();

                return ID;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }
    }
}
