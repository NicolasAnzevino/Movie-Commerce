using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Movie_Commerce
{
    public partial class PeliculaControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Añadir a carrito

            BLL_Usuario BLL_Usuario = new BLL_Usuario();
            BLL_Usuario.Agregar_Pelicula_a_Carrito(((Entidades.Usuario)Session["Usuario"]).ID, int.Parse(lblID.Text));
            lblComprar.Visible = true;            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Ver

            Session["IDPel"] = lblID.Text;
            Response.Redirect("FormVerPelicula.aspx", false);
        }
    }
}