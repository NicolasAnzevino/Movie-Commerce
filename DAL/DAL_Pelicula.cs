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
    public class DAL_Pelicula : SQLKit
    {
        public DAL_Pelicula() : base()
        {

        }

        public DataTable Ver_Generos()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Genero";

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public int Insertar_Pelicula_Temporal()
        {
            try
            {
                Conectarse();

                int ID = 0;

                Comando.CommandText = "if (select max(peli_codigo) from Pelicula) is null begin select 0 end else begin select max(peli_codigo) from Pelicula end";

                ID = (int)Comando.ExecuteScalar() + 1;

                //Comando.CommandText = "INSERT INTO TempPeli_ID VALUES (@pID)";
                //Comando.Parameters.Clear();
                //Comando.Parameters.AddWithValue("pID", ID);

                //Comando.ExecuteNonQuery();

                Desconectarse();

                return ID;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Agregar_Pelicula(Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "INSERT INTO PELICULA VALUES (@pID, @pNombre, @pDescripcion, @pPrecio, @pImagen, @pPoseeImagen)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.Parameters.AddWithValue("pNombre", pPelicula.Nombre);
                Comando.Parameters.AddWithValue("pDescripcion", pPelicula.Descripcion);
                Comando.Parameters.AddWithValue("pPrecio", pPelicula.Precio);
                Comando.Parameters.AddWithValue("pImagen", pPelicula.Imagen);
                Comando.Parameters.AddWithValue("pPoseeImagen", pPelicula.PoseeImagen);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataRow Obtener_Genero_con_ID(string pNombre)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "select * from genero where gene_nombre = @pNombre";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pNombre", pNombre);

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT.Rows[0];
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Insertar_Relacion_Genero_Pelicula(Genero pGenero, Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "INSERT INTO PeliculaGenero (PelGen_Peli_Codigo, PelGen_Gene_Codigo) VALUES (@pPeliID, @pGeneID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pPeliID", pPelicula.Codigo);
                Comando.Parameters.AddWithValue("pGeneID", pGenero.Codigo);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Pelicula(int pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Pelicula WHERE Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pID);

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Generos_de_Pelicula(int pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT Gene_Codigo, Gene_Nombre FROM Genero JOIN PeliculaGenero ON (Gene_Codigo = PelGen_Gene_Codigo AND PelGen_Peli_Codigo = @pID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pID);

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Ver_Peliculas()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Pelicula";
                Comando.Parameters.Clear();

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Eliminar_Pelicula(Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "DELETE PeliculaGenero WHERE PelGen_Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.ExecuteNonQuery();

                Comando.CommandText = "DELETE Pelicula WHERE Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Eliminar_Generos_de_Pelicula(Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "DELETE PeliculaGenero WHERE PelGen_Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Modificar_Pelicula_Cambia_Imagen(Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "UPDATE Pelicula SET Peli_Nombre = @pNombre, Peli_Descripcion = @pDesc, Peli_Precio = @pPrecio, Peli_Imagen = @pImagen, Peli_PoseeImagen = @pPoseeImagen WHERE Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.Parameters.AddWithValue("pNombre", pPelicula.Nombre);
                Comando.Parameters.AddWithValue("pDesc", pPelicula.Descripcion);
                Comando.Parameters.AddWithValue("pPrecio", pPelicula.Precio);
                Comando.Parameters.AddWithValue("pImagen", pPelicula.Imagen);
                Comando.Parameters.AddWithValue("pPoseeImagen", pPelicula.PoseeImagen);
                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Modificar_Pelicula_No_Cambia_Imagen(Pelicula pPelicula)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "UPDATE Pelicula SET Peli_Nombre = @pNombre, Peli_Descripcion = @pDesc, Peli_Precio = @pPrecio WHERE Peli_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pPelicula.Codigo);
                Comando.Parameters.AddWithValue("pNombre", pPelicula.Nombre);
                Comando.Parameters.AddWithValue("pDesc", pPelicula.Descripcion);
                Comando.Parameters.AddWithValue("pPrecio", pPelicula.Precio);
                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }
    }
}
