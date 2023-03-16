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
    public partial class FormRegistrarse : System.Web.UI.Page
    {
        BLL_Usuario BLL_Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL_Usuario = new BLL_Usuario();
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (TextBoxNombre.Text != "" && TextBoxPassword.Text != "" && TextBoxxCPassword.Text != "" && TextBoxUsuario.Text != "" && TextBoxApellido.Text != "" && TextBoxDNI.Text != "")
            {
                if (BLL_Usuario.VerificarNombreUsuario(TextBoxUsuario.Text)) //Verifica SI existe.
                {
                    lblUsuario.Text += " - Ya hay una cuenta con ese Nombre de Usuario, ingrese otro";
                    lblUsuario.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
                else if (TextBoxPassword.Text != TextBoxxCPassword.Text)
                {
                    lblPassword.Text += " - Las contraseñadas ingresadas no coinciden";
                    lblPassword.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
                }
                else
                {
                    BLL_Usuario.Registrar_Usuario_Cliente(new Usuario(1, TextBoxUsuario.Text, TextBoxPassword.Text, TextBoxNombre.Text, TextBoxApellido.Text, TextBoxDNI.Text));
                    Response.Write("<script type=\"text/javascript\">alert('Usuario Registrado correctamente');</script>");
                    Response.Redirect("FormLogin.aspx");
                }
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormLogin.aspx");
        }
    }
}