using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using MAP;

namespace BLL
{
    public class BLL_Rol
    {
        MAP_Rol MAP_Rol;

        public BLL_Rol()
        {
            MAP_Rol = new MAP_Rol();
        }

        public Rol Buscar_Rol(int pID)
        {
            return MAP_Rol.Buscar_Rol(pID);
        }

        public List<Permiso> Ver_Permisos()
        {
            return MAP_Rol.Ver_Permisos();
        }
        public List<Permiso> Ver_Permisos_New()
        {
            return MAP_Rol.Ver_Permisos_New();
        }

        public List<Rol> Ver_Roles_Con_Permisos()
        {
            List<Rol> Roles = MAP_Rol.Ver_Roles();

            foreach (Rol R in Roles)
            {
                MAP_Rol.AsignarPermisos(R);
            }

            return Roles;
        }
    }
}
