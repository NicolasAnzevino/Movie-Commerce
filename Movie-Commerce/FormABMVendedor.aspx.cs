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
    public partial class FormABMVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario = new BLL_Usuario();

                U = (Usuario)Session["Usuario"];

                if (U == null)
                {
                    throw new Exception("No se ha ingresado con un usuario");
                }

                if (Session["Accion"].ToString() != "Agregar")
                {
                    Usuario_Seleccionado = BLL_Usuario.Obtener_Vendedor(Session["IDRow"].ToString());
                }

                if (!Page.IsPostBack)
                {
                    linklblInicio.Visible = true;

                    Botones.Add(linklblInicio);
                    Botones.Add(linklblCerrarSesion);
                    Botones.Add(linklblVerProductos);
                    Botones.Add(linklblMenuAdministrador);
                    Botones.Add(linklblMenuVendedor);
                    Botones.Add(linklblVerMisCompras);
                    Botones.Add(linklblRegistrarse);
                    Botones.Add(linklblCarrito);

                    HabilitarLinkButtons();
                    SetFormMode(Session["Accion"].ToString());
                }
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        Usuario U, Usuario_Seleccionado;
        BLL_Usuario BLL_Usuario;
        public List<LinkButton> Botones = new List<LinkButton>();

        #region LinkButtons
        protected void linklblInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMainMenu.aspx");
        }
        protected void linklblVerProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormVerProductos.aspx");
        }
        protected void linklblMenuAdministrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMenuAdministrador.aspx");
        }

        protected void linklblMenuVendedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMenuVendedor.aspx");
        }

        protected void linklblVerMisCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormVerMisCompras.aspx");
        }

        protected void linklblCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormVerCarrito.aspx");
        }

        protected void linklblRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormRegistrarse.aspx");
        }

        protected void linklblCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormLogin.aspx");
        }

        protected void linklbltitulo_Click(object sender, EventArgs e)
        {

        }

        protected void HabilitarLinkButtons()
        {
            foreach (LinkButton b in Botones)
            {
                if (U.Rol.Validar(b.CommandName))
                {
                    b.Visible = true;
                }
            }

            if (U.Rol.Validar("Agregar Vendedor"))
            {
                linklblMenuAdministrador.Visible = true;
            }

            if (U.Rol.Validar("Agregar Producto"))
            {
                linklblMenuVendedor.Visible = true;
            }

            if (U.Rol.Validar("Ver mis Productos"))
            {
                linklblMenuVendedor.Visible = true;
            }

            if (U.Rol.Validar("Ver Productos"))
            {
                linklblVerProductos.Visible = true;
            }

            if (U.Rol.Validar("Ver Carrito"))
            {
                linklblCarrito.Visible = true;
            }

            if (U.Rol.Validar("Ver mis Compras"))
            {
                linklblVerMisCompras.Visible = true;
            }

            if (U.Rol.Validar("Registrarse"))
            {
                linklblRegistrarse.Visible = true;
            }
        }

        #endregion

        public void SetFormMode(string pMode)
        {
            switch (pMode)
            {
                case "Ver":

                    lblTitulo.Text = "Ver Vendedor";

                    //Usuario_Seleccionado = BLL_Usuario.Obtener_Vendedor(Session["IDRow"].ToString());
                    lblPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    TextBoxxCPassword.Visible = false;
                    btnRegistrarse.Visible = false;
                    TextBoxID.Text = Usuario_Seleccionado.ID.ToString();
                    TextBoxDNI.Text = Usuario_Seleccionado.DNI.ToString();
                    TextBoxUsuario.Text = Usuario_Seleccionado.Nombre.ToString();
                    TextBoxNombre.Text = Usuario_Seleccionado.NombreReal.ToString();
                    TextBoxApellido.Text = Usuario_Seleccionado.Apellido.ToString();

                    TextBoxID.ReadOnly = true;
                    TextBoxDNI.ReadOnly = true;
                    TextBoxUsuario.ReadOnly = true;
                    TextBoxNombre.ReadOnly = true;
                    TextBoxApellido.ReadOnly = true;
                    break;

                case "Agregar":

                    lblTitulo.Text = "Agregar Vendedor";
                    lblID.Visible = false;
                    TextBoxID.Visible = false;
                    break;

                case "Modificar":

                    lblTitulo.Text = "Modificar Vendedor";

                    //Usuario_Seleccionado = BLL_Usuario.Obtener_Vendedor(Session["IDRow"].ToString());
                    lblPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    TextBoxxCPassword.Visible = false;
                    TextBoxID.ReadOnly = true;
                    TextBoxUsuario.ReadOnly = true;

                    TextBoxID.Text = Usuario_Seleccionado.ID.ToString();
                    TextBoxDNI.Text = Usuario_Seleccionado.DNI.ToString();
                    TextBoxUsuario.Text = Usuario_Seleccionado.Nombre.ToString();
                    TextBoxNombre.Text = Usuario_Seleccionado.NombreReal.ToString();
                    TextBoxApellido.Text = Usuario_Seleccionado.Apellido.ToString();
                    btnRegistrarse.Text = "Modificar";
                    break;

                case "Eliminar":

                    lblTitulo.Text = "Eliminar Vendedor";

                    //Usuario_Seleccionado = BLL_Usuario.Obtener_Vendedor(Session["IDRow"].ToString());
                    lblPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    TextBoxxCPassword.Visible = false;
                    btnRegistrarse.Visible = true;
                    TextBoxID.Text = Usuario_Seleccionado.ID.ToString();
                    TextBoxDNI.Text = Usuario_Seleccionado.DNI.ToString();
                    TextBoxUsuario.Text = Usuario_Seleccionado.Nombre.ToString();
                    TextBoxNombre.Text = Usuario_Seleccionado.NombreReal.ToString();
                    TextBoxApellido.Text = Usuario_Seleccionado.Apellido.ToString();

                    TextBoxID.ReadOnly = true;
                    TextBoxDNI.ReadOnly = true;
                    TextBoxUsuario.ReadOnly = true;
                    TextBoxNombre.ReadOnly = true;
                    TextBoxApellido.ReadOnly = true;
                    btnRegistrarse.Text = "Eliminar";
                    break;
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            switch (Session["Accion"].ToString())
            {
                case "Ver":
                    break;

                case "Agregar":

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
                            BLL_Usuario.Registrar_Usuario_Vendedor(new Usuario(1, TextBoxUsuario.Text, TextBoxPassword.Text, TextBoxNombre.Text, TextBoxApellido.Text, TextBoxDNI.Text));
                            Response.Write("<script type=\"text/javascript\">alert('Usuario Registrado correctamente');</script>");
                            Response.Redirect("FormGestionVendedores.aspx", false);
                        }
                    }

                    break;

                case "Modificar":

                    if (TextBoxNombre.Text != "" && TextBoxDNI.Text != "" && TextBoxApellido.Text != "")
                    {
                        Usuario_Seleccionado.Apellido = TextBoxApellido.Text;
                        Usuario_Seleccionado.NombreReal = TextBoxNombre.Text;
                        Usuario_Seleccionado.DNI = TextBoxDNI.Text;
                        BLL_Usuario.Modificar_Usuario_Vendedor(Usuario_Seleccionado);
                        Response.Write("<script type=\"text/javascript\">alert('Vendedor Modificado correctamente');</script>");
                        Response.Redirect("FormGestionVendedores.aspx", false);
                    }


                    break;

                case "Eliminar":

                    BLL_Usuario.Eliminar_Usuario_Vendedor(Usuario_Seleccionado);
                    Response.Write("<script type=\"text/javascript\">alert('Vendedor Eliminado correctamente');</script>");
                    Response.Redirect("FormGestionVendedores.aspx", false);

                    break;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormGestionVendedores.aspx", false);
        }
    }
}