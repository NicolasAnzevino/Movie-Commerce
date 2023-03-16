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
    public class MAP_Rol
    {
        DAL_Rol DAL_Rol;
        public MAP_Rol()
        {
            DAL_Rol = new DAL_Rol();
        }

        public List<Rol> Ver_Roles()
        {
            DataTable DT = DAL_Rol.Ver_Roles();
            List<Rol> LR = new List<Rol>();

            foreach (DataRow DR in DT.Rows)
            {
                LR.Add(new Rol(DR.ItemArray));
            }

            return LR;
        }

        public Rol Buscar_Rol(int pID)
        {
            DataTable DT = DAL_Rol.Buscar_Rol(pID);

            Rol R = new Rol(DT.Rows[0].ItemArray);

            return R;
        }

        public List<Permiso> Ver_Permisos()
        {
            try
            {
                List<Permiso> LP = new List<Permiso>();

                DataTable DTPermisos = DAL_Rol.Ver_Permisos();

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
                    DataTable DTHijos = DAL_Rol.Obtener_Hijos(fp.ID);

                    foreach (DataRow hijo in DTHijos.Rows)
                    {
                        fp.AgregarPermiso(new PermisoSimple(hijo.Field<int>(0), hijo.Field<string>(1)));
                    }
                }

                foreach (DataRow dataRow in DTPermisos.Rows)
                {
                    if (dataRow.Field<bool>(2) is false)
                    {
                        PermisoSimple ps = new PermisoSimple(dataRow.Field<int>(0), dataRow.Field<string>(1));
                        LP.Add(ps);
                    }
                }

                //DataTable DTFamilias = DAL_Rol.Obtener_Familias();

                //foreach (DataRow dr in DTPermisos.Rows) //Sueltos
                //{
                //    if (dr.Field<bool>(2) is false)
                //    {
                //        bool huerfano = true;
                //        foreach (DataRow drfam in DTFamilias.Rows)
                //        {
                //            if (drfam.Field<int>(1) == dr.Field<int>(0) && LP.Exists(x => x.ID == drfam.Field<int>(2)))
                //            {
                //                huerfano = false;
                //                break;
                //            }
                //        }
                //        if (huerfano)
                //        {
                //            PermisoSimple ps = new PermisoSimple(dr.Field<int>(0), dr.Field<string>(1));
                //            LP.Add(ps);
                //        }
                //    }
                //}

                return LP;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<Permiso> Ver_Permisos_New()
        {
            try
            {
                List<Permiso> LP = new List<Permiso>();

                DataTable DTPermisos = DAL_Rol.Ver_Permisos();

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
                    DataTable DTHijos = DAL_Rol.Obtener_Hijos(fp.ID);

                    foreach (DataRow hijo in DTHijos.Rows)
                    {
                        fp.AgregarPermiso(new PermisoSimple(hijo.Field<int>(0), hijo.Field<string>(1)));
                    }
                }

                foreach (DataRow dataRow in DTPermisos.Rows)
                {
                    if (dataRow.Field<bool>(2) is false)
                    {
                        PermisoSimple ps = new PermisoSimple(dataRow.Field<int>(0), dataRow.Field<string>(1));
                        LP.Add(ps);
                    }
                }

                //DataTable DTFamilias = DAL_Rol.Obtener_Familias();

                //foreach (DataRow dr in DTPermisos.Rows) //Sueltos
                //{
                //    if (dr.Field<bool>(2) is false)
                //    {
                //        bool huerfano = true;
                //        foreach (DataRow drfam in DTFamilias.Rows)
                //        {
                //            if (drfam.Field<int>(1) == dr.Field<int>(0) && LP.Exists(x => x.ID == drfam.Field<int>(2)))
                //            {
                //                huerfano = false;
                //                break;
                //            }
                //        }
                //        if (huerfano)
                //        {
                //            PermisoSimple ps = new PermisoSimple(dr.Field<int>(0), dr.Field<string>(1));
                //            LP.Add(ps);
                //        }
                //    }
                //}

                return LP;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }



        //public bool Verificar_Nombre(string pNombre)
        //{
        //    try
        //    {
        //        return DAL_Rol.Verificar_Nombre(pNombre);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //public void Agregar_Rol(string pNombre, List<Permiso> pLP)
        //{
        //    try
        //    {
        //        int ID = DAL_Rol.Agregar_Rol(pNombre);

        //        foreach (Permiso Permiso in pLP)
        //        {
        //            DAL_Rol.Asignar_Permiso_a_Rol(ID, Permiso);
        //        }
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        public void AsignarPermisos(Rol pRol)
        {
            try
            {
                List<Permiso> LP = pRol.VerPermisos();

                DataTable DTPermisos = DAL_Rol.Obtener_Permisos(pRol.ID);

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
                    DataTable DTHijos = DAL_Rol.Obtener_Hijos(fp.ID);

                    foreach (DataRow hijo in DTHijos.Rows)
                    {
                        fp.AgregarPermiso(new PermisoSimple(hijo.Field<int>(0), hijo.Field<string>(1)));
                    }
                }

                DataTable DTFamilias = DAL_Rol.Obtener_Familias();

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
    }
}
