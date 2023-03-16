using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MAP;
using System.Data;

namespace BLL
{
    public class BLL_Usuario
    {
        public MAP_Usuario MAP_Usuario;
        public BLL_Usuario()
        {
            MAP_Usuario = new MAP_Usuario();
        }

        public bool VerificarNombreUsuario(string pNombreUsuario)
        {
            return MAP_Usuario.VerificarNombreUsuario(pNombreUsuario);
        }

        public void Registrar_Usuario_Cliente(Usuario pUsuario)
        {
            MAP_Usuario.Registrar_Usuario_Cliente(pUsuario);
        }

        public void Registrar_Usuario_Vendedor(Usuario pUsuario)
        {
            MAP_Usuario.Registrar_Usuario_Vendedor(pUsuario);
        }

        public void Modificar_Usuario_Vendedor(Usuario pUsuario)
        {
            MAP_Usuario.Modificar_Usuario_Vendedor(pUsuario);
        }

        public void Eliminar_Usuario_Vendedor(Usuario pUsuario)
        {
            MAP_Usuario.Eliminar_Usuario_Vendedor(pUsuario);
        }

        public bool Verificar_Usuario_Password(Usuario pUsuario)
        {
            if (MAP_Usuario.Verificar_Password(pUsuario) && (MAP_Usuario.VerificarNombreUsuario(pUsuario.Nombre)))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public Rol Asignar_Rol(Usuario pUsuario)
        {
            try
            {
                Rol R;

                DataTable DT = MAP_Usuario.Obtener_Rol(pUsuario.ID);

                R = new Rol(DT.Rows[0].ItemArray);

                AsignarPermisos(R);

                return R;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void AsignarPermisos(Rol pRol)
        {
            try
            {
                List<Permiso> LP = pRol.VerPermisos();

                DataTable DTPermisos = MAP_Usuario.Obtener_Permisos(pRol.ID);

                foreach (DataRow dr in DTPermisos.Rows) //Familias de Rol
                {
                    if (dr.Field<bool>(2) is true)
                    {
                        PermisoCompuesto fp = new PermisoCompuesto(dr.Field<int>(0), dr.Field<string>(1));
                        LP.Add(fp);
                    }
                }

                foreach (PermisoCompuesto fp in LP) //Hijos de Familia
                {
                    DataTable DTHijos = MAP_Usuario.Obtener_Hijos(fp.ID);

                    foreach (DataRow hijo in DTHijos.Rows)
                    {
                        if (hijo.Field<bool>(2) is false)
                        {
                            fp.AgregarPermiso(new PermisoSimple(hijo.Field<int>(0), hijo.Field<string>(1)));
                        }
                        else
                        {
                            PermisoCompuesto permisoCompuesto = new PermisoCompuesto(hijo.Field<int>(0), hijo.Field<string>(1));
                            fp.AgregarPermiso(permisoCompuesto);
                            ObtenerPermisosRecursivo(permisoCompuesto);
                        }
                    }
                }

                DataTable DTFamilias = MAP_Usuario.Obtener_Familias();

                foreach (DataRow dr in DTPermisos.Rows) //Sueltos
                {
                    if (dr.Field<bool>(2) is false)
                    {
                        bool huerfano = true;
                        foreach (DataRow drfam in DTFamilias.Rows)
                        {
                            if (drfam.Field<int>(1) == dr.Field<int>(0) && LP.Exists(x => x.ID == drfam.Field<int>(2)))
                            {
                                huerfano = false;
                                break;
                            }
                        }
                        if (huerfano)
                        {
                            PermisoSimple ps = new PermisoSimple(dr.Field<int>(0), dr.Field<string>(1));
                            LP.Add(ps);
                        }
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public void ObtenerPermisosRecursivo(PermisoCompuesto pFP)
        {
            DataTable DTHijos = MAP_Usuario.Obtener_Hijos(pFP.ID);

            foreach (DataRow hijo in DTHijos.Rows)
            {
                if (hijo.Field<bool>(2) is false)
                {
                    pFP.AgregarPermiso(new PermisoSimple(hijo.Field<int>(0), hijo.Field<string>(1)));
                }
                else
                {
                    PermisoCompuesto PC = new PermisoCompuesto(hijo.Field<int>(0), hijo.Field<string>(1));
                    pFP.AgregarPermiso(PC);
                    ObtenerPermisosRecursivo(PC);
                }
            }
        }

        public Usuario GetData(Usuario pUsuario)
        {
            Usuario U = MAP_Usuario.GetData(pUsuario);

            U.Rol = Asignar_Rol(U);

            return U;            
        }

        public List<Usuario> Ver_Usuarios_Vendedores()
        {
            return MAP_Usuario.Ver_Usuarios_Vendedores();
        }

        public List<Usuario_Vista> Ver_Usuarios_Vendedores_Vista()
        {
            return MAP_Usuario.Ver_Usuarios_Vendedores_Vista();
        }

        public Usuario Obtener_Vendedor(string pID)
        {
            return MAP_Usuario.Obtener_Vendedor(pID);
        }

        public void Agregar_Pelicula_a_Carrito(int pUserID, int pPeliID)
        {
            MAP_Usuario.Agregar_Pelicula_a_Carrito(pUserID, pPeliID);
        }
    }
}
