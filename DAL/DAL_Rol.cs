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
    public class DAL_Rol : SQLKit
    {
        public DAL_Rol() : base()
        {

        }

        public DataTable Ver_Roles()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Rol WHERE Rol_Nombre != 'Super Administrador' AND Rol_Nombre != 'Director de estudios'";

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable Buscar_Rol(int pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT * FROM Rol WHERE Rol_Codigo = @pCodigoRol";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pCodigoRol", pID);

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public DataTable Ver_Permisos()
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT DISTINCT Perm_Codigo, Perm_Nombre, Perm_EsPadre FROM Permiso";
                //Comando.CommandText = "SELECT DISTINCT Perm_Codigo, Perm_Nombre, Perm_EsPadre FROM Permiso, PermisoRol WHERE PermRol_Perm_Codigo = Perm_Codigo";

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
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

        public DataTable Obtener_Permisos_De_Compuesto(int pID)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT Perm_Codigo, Perm_Nombre FROM Permiso, Compuesto WHERE Comp_Padre_Codigo = @pID AND Comp_Perm_Codigo = Perm_Codigo";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pID", pID);

                DataTable DT = new DataTable();
                SqlDataReader DR = Comando.ExecuteReader();
                DT.Load(DR);

                Desconectarse();

                return DT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public bool Verificar_Nombre(string pNombre)
        {
            try
            {
                bool ExisteUsuario = false; //False no existe || True sí

                Conectarse();

                Comando.CommandText = "SELECT Rol_Nombre FROM Rol WHERE Rol_Nombre = @pNombre";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@pNombre", pNombre);

                DataTable DT = new DataTable();
                SqlDataReader Reader = Comando.ExecuteReader();

                DT.Load(Reader);

                if (DT.Rows.Count > 0)
                {
                    ExisteUsuario = true;
                }

                Desconectarse();

                return ExisteUsuario;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }

        public int Agregar_Rol(string pNombre)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "SELECT MAX(Rol_Codigo) FROM Rol";

                int ID = (int)Comando.ExecuteScalar();

                ID++;

                Comando.CommandText = "INSERT INTO Rol (Rol_Codigo, Rol_Nombre) VALUES (@pID, @pNombre)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@pNombre", pNombre);
                Comando.Parameters.AddWithValue("@pID", ID);

                Comando.ExecuteNonQuery();

                Desconectarse();

                return ID;
            }
            catch (Exception ex) { Desconectarse(); throw new Exception(ex.Message); }
        }
        public void Asignar_Permiso_a_Rol(int pID, Permiso P)
        {
            try
            {
                Conectarse();

                Comando.CommandText = "INSERT INTO PermisoRol(PermRol_Rol_Codigo, PermRol_Perm_Codigo) VALUES (@pRolID, @pPermisoID)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("pRolID", pID);
                Comando.Parameters.AddWithValue("pPermisoID", P.ID);

                Comando.ExecuteNonQuery();

                Desconectarse();
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
    }
}
