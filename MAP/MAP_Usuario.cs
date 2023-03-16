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
    public class MAP_Usuario
    {
        public DAL_Usuario DAL_Usuario;
        public MAP_Usuario()
        {
            DAL_Usuario = new DAL_Usuario();
        }

        public bool VerificarNombreUsuario(string pNombreUsuario)
        {
            return DAL_Usuario.VerificarNombreUsuario(pNombreUsuario);
        }

        public void Registrar_Usuario_Cliente(Usuario pUsuario)
        {
            DAL_Usuario.Registrar_Usuario_Cliente(pUsuario);
        }

        public void Registrar_Usuario_Vendedor(Usuario pUsuario)
        {
            DAL_Usuario.Registrar_Usuario_Vendedor(pUsuario);
        }

        public void Modificar_Usuario_Vendedor(Usuario pUsuario)
        {
            DAL_Usuario.Modificar_Usuario_Vendedor(pUsuario);
        }

        public void Eliminar_Usuario_Vendedor(Usuario pUsuario)
        {
            DAL_Usuario.Eliminar_Usuario_Vendedor(pUsuario);
        }

        public bool Verificar_Password(Usuario pUsuario) //Verifica que exista el usuario
        {
            return DAL_Usuario.Verificar_Password(pUsuario);
        }

        public Usuario GetData(Usuario pUsuario)
        {
            DataTable DTDatos = DAL_Usuario.GetData(pUsuario);

            Usuario U = new Usuario(DTDatos.Rows[0].Field<int>(0), pUsuario.Nombre, "", DTDatos.Rows[0].Field<string>(1), DTDatos.Rows[0].Field<string>(2), DTDatos.Rows[0].Field<string>(3));
            U.Rol.ID = DTDatos.Rows[0].Field<int>(4);
            U.Rol.Nombre = DTDatos.Rows[0].Field<string>(5);

            return U;            
        }

        public DataTable Obtener_Rol(int pID)
        {
            return DAL_Usuario.Obtener_Rol(pID);
        }

        public DataTable Obtener_Hijos(int pID)
        {
            return DAL_Usuario.Obtener_Hijos(pID);
        }

        public DataTable Obtener_Permisos(int pID)
        {
            return DAL_Usuario.Obtener_Permisos(pID);
        }

        public DataTable Obtener_Familias()
        {
            return DAL_Usuario.Obtener_Familias();
        }

        public List<Usuario> Ver_Usuarios_Vendedores()
        {
            DataTable DT = DAL_Usuario.Ver_Usuarios_Vendedores();

            List<Usuario> LU = new List<Usuario>();

            foreach (DataRow DR in DT.Rows)
            {
                LU.Add(new Usuario(DR.Field<int>(0), DR.Field<string>(1), DR.Field<string>(2), DR.Field<string>(3)));
            }

            return LU;
        }

        public List<Usuario_Vista> Ver_Usuarios_Vendedores_Vista()
        {
            DataTable DT = DAL_Usuario.Ver_Usuarios_Vendedores();

            List<Usuario_Vista> LU = new List<Usuario_Vista>();

            foreach (DataRow DR in DT.Rows)
            {
                LU.Add(new Usuario_Vista(DR.Field<int>(0), DR.Field<string>(1), DR.Field<string>(2), DR.Field<string>(3)));
            }

            return LU;
        }

        public Usuario Obtener_Vendedor(string pID)
        {
            DataTable DT = DAL_Usuario.Obtener_Vendedor(pID);

            Usuario U = new Usuario();

            U = new Usuario(DT.Rows[0].Field<int>(0), DT.Rows[0].Field<string>(1), DT.Rows[0].Field<string>(2), DT.Rows[0].Field<string>(3), DT.Rows[0].Field<string>(4));

            return U;
        }

        public void Agregar_Pelicula_a_Carrito(int pUserID, int pPeliID)
        {
            DAL_Usuario.Agregar_Pelicula_a_Carrito(pUserID, pPeliID);
        }

    }
}
