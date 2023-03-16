using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario_Vista
    {
        public Usuario_Vista(int pID, string pApellido, string pNombre, string pDNI)
        {
            ID = pID;
            Apellido = pApellido;
            Nombre = pNombre;
            DNI = pDNI;
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }
}
