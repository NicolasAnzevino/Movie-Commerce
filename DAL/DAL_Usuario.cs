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
    public class DAL_Usuario : SQLKit
    {
        public DAL_Usuario() : base()
        {

        }

        public bool VerificarNombreUsuario(string pNombreUsuario)
        {
            try
            {
                Conectarse();

                bool B = false; //false -> no existe, true -> sí

                Comando.CommandText = "select count(user_nombre) from usuario where user_nombre = @pUsuario";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pUsuario", pNombreUsuario);

                int Total = (int)Comando.ExecuteScalar();

                if (Total != 0) { B = true; }
                else { B = false; }

                Desconectarse();

                return B;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Registrar_Usuario_Cliente(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "insert into usuario (user_nombre, user_contraseña, user_nombre_Real, user_apellido, user_dni, user_rol_codigo) values (@pNombre, @pPass, @pNR, @pAp, @pDNI, '3')";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pNombre", pUsuario.Nombre);
                Comando.Parameters.AddWithValue("pPass", pUsuario.Password);
                Comando.Parameters.AddWithValue("pNR", pUsuario.NombreReal);
                Comando.Parameters.AddWithValue("pAp", pUsuario.Apellido);
                Comando.Parameters.AddWithValue("pDNI", pUsuario.DNI);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Registrar_Usuario_Vendedor(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "insert into usuario (user_nombre, user_contraseña, user_nombre_Real, user_apellido, user_dni, user_rol_codigo) values (@pNombre, @pPass, @pNR, @pAp, @pDNI, '2')";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pNombre", pUsuario.Nombre);
                Comando.Parameters.AddWithValue("pPass", pUsuario.Password);
                Comando.Parameters.AddWithValue("pNR", pUsuario.NombreReal);
                Comando.Parameters.AddWithValue("pAp", pUsuario.Apellido);
                Comando.Parameters.AddWithValue("pDNI", pUsuario.DNI);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Modificar_Usuario_Vendedor(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "UPDATE Usuario SET User_Nombre_Real = @pNombreReal, User_Apellido = @pApellido, User_DNI = @pDNI WHERE User_Codigo = @pID";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pNombreReal", pUsuario.NombreReal);
                Comando.Parameters.AddWithValue("pApellido", pUsuario.Apellido);
                Comando.Parameters.AddWithValue("pDNI", pUsuario.DNI);
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Eliminar_Usuario_Vendedor(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "DELETE Usuario WHERE User_Codigo = @pID";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pUsuario.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public bool Verificar_Password(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                bool B = false; //false -> no existe, true -> sí

                Comando.CommandText = "select count(user_nombre) from usuario where user_nombre = @pUsuario and user_contraseña = @pPassword";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pUsuario", pUsuario.Nombre);
                Comando.Parameters.AddWithValue("pPassword", pUsuario.Password);

                int Total = (int)Comando.ExecuteScalar();

                if (Total != 0) { B = true; }
                else { B = false; }

                Desconectarse();

                return B;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable GetData(Usuario pUsuario)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT User_Codigo, User_Nombre_Real, User_Apellido, User_DNI, Rol_Codigo, Rol_Nombre FROM Usuario JOIN Rol ON (User_Rol_Codigo = Rol_Codigo) WHERE User_Nombre = @pNombre";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@pNombre", pUsuario.Nombre);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Rol(int pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Rol Where Rol_Codigo = (SELECT User_Rol_Codigo FROM USUARIO WHERE User_Codigo = @ID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@ID", pID);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }
        public DataTable Obtener_Permisos(int pCodigo)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT Perm_Codigo, Perm_Nombre, Perm_EsPadre FROM Permiso, PermisoRol WHERE PermRol_Perm_Codigo = Perm_Codigo and PermRol_Rol_Codigo = @ID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@ID", pCodigo);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;

            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Familias()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Compuesto";

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Hijos(int pID_Padre)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT Perm_Codigo, Perm_Nombre, Perm_EsPadre FROM Permiso, Compuesto WHERE Comp_Perm_Codigo = Perm_Codigo AND Comp_Padre_Codigo = @ID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@ID", pID_Padre);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Ver_Usuarios_Vendedores()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT 'ID' = User_Codigo, 'Apellido' = User_Apellido, 'Nombre' = User_Nombre_Real, 'DNI' = User_DNI FROM Usuario WHERE User_Rol_Codigo = '2'";
                Comando.Parameters.Clear();

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public DataTable Obtener_Vendedor(string pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT 'ID' = User_Codigo, 'Nombre_Us' = User_Nombre, 'Apellido' = User_Apellido, 'Nombre' = User_Nombre_Real, 'DNI' = User_DNI FROM Usuario WHERE User_Rol_Codigo = '2' AND User_Codigo = @pID";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@pID", pID);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();
                DT.Load(Reader);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public void Agregar_Pelicula_a_Carrito(int pUserID, int pPeliID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "insert into carritocompra (carr_peli_codigo, carr_user_codigo) values (@pPeliID, @pUserID)";

                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pPeliID", pPeliID);
                Comando.Parameters.AddWithValue("pUserID", pUserID);

                Comando.ExecuteNonQuery();

                Desconectarse();
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }
    }


}
