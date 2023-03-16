using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace Movie_Commerce
{
    public partial class FormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrecto.Visible = false;
            BLL_Usuario = new BLL_Usuario();
        }

        Usuario U;
        BLL_Usuario BLL_Usuario;

        protected void linkbtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormRegistrarse.aspx");
        }

        protected void linkbtnGuest_Click(object sender, EventArgs e)
        {
            U = new Usuario();
            U.Nombre = "Invitado";
            U.Password = "dfe37c20733aad4254cf930e50cd0952";
            U = BLL_Usuario.GetData(U);
            Session["Usuario"] = U;
            Response.Redirect("FormMainMenu.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (TextBoxUsuario.Text != "" && TextBoxPassword.Text != "")
            {
                if (TextBoxUsuario.Text != "Invitado")
                {
                    U = new Usuario();

                    U.Nombre = TextBoxUsuario.Text;
                    U.Password = TextBoxPassword.Text;

                    if (BLL_Usuario.Verificar_Usuario_Password(U))
                    {
                        U = BLL_Usuario.GetData(U);
                        Session["Usuario"] = U;
                        Response.Redirect("FormMainMenu.aspx");
                    }
                    else
                    {
                        lblIncorrecto.Visible = true;
                    }
                }               

            }
        }
    }
}