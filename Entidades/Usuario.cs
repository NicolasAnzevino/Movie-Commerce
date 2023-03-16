using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Rol = new Rol();
        }

        public Usuario(int pID, string pApellido, string pNombreReal, string pDNI)
        {
            ID = pID;
            Apellido = pApellido;
            NombreReal = pNombreReal;
            DNI = pDNI;

            Rol = new Rol();
        }

        public Usuario(int pID, string pNombre, string pPassword, string pNombreReal, string pApellido, string pDNI)
        {
            ID = pID;
            Nombre = pNombre;
            Password = pPassword;
            NombreReal = pNombreReal;
            Apellido = pApellido;
            DNI = pDNI;

            Rol = new Rol();
        }

        public Usuario(int pID, string pNombre, string pApellido, string pNombreReal, string pDNI)
        {
            ID = pID;
            Nombre = pNombre;
            Apellido = pApellido;
            NombreReal = pNombreReal;
            DNI = pDNI;

            Rol = new Rol();
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string NombreReal { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        public Rol Rol { get; set; }
    }    
}
