using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SQLKit
    {
        protected SqlConnection Conexion;
        protected SqlCommand Comando;

        public SQLKit()
        {
            Conexion = new SqlConnection(@"Data Source=DESKTOP-ICCJCO5;Initial Catalog=Movie-Commerce;Integrated Security=True");
            Comando = new SqlCommand("", Conexion);
        }

        public void Conectarse()
        {
            try
            {
                Conexion.Open();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public void Desconectarse()
        {
            try
            {
                Conexion.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
