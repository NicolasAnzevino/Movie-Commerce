using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        public Rol()
        {

        }
        public Rol(int pCodigo, string pNombre)
        {
            ID = pCodigo;
            Nombre = pNombre;
            Permisos = new List<Permiso>();
        }
        public Rol(string pNombre)
        {
            Nombre = pNombre;
        }

        public Rol(object[] pO)
        {
            ID = (int)pO[0];
            Nombre = (string)pO[1];
            Permisos = new List<Permiso>();
        }


        public int ID { get; set; }
        public string Nombre { get; set; }

        public List<Permiso> Permisos;

        public List<Permiso> VerPermisos()
        {
            return this.Permisos;
        }

        public bool Validar(string pCodigo)
        {
            List<Permiso> LP = new List<Permiso>();

            foreach (Permiso P in Permisos)
            {
                LP.AddRange(P.RetornaPermisos());
            }

            return LP.Exists(X => X.Codigo == pCodigo);
        }

        public override string ToString()
        {
            return Nombre.ToString();
        }


    }
}
