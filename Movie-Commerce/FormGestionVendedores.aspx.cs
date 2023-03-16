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
    public partial class FormGestionVendedores : System.Web.UI.Page
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

                gvVendedores.DataSource = null;
                gvVendedores.DataSource = BLL_Usuario.Ver_Usuarios_Vendedores_Vista();
                gvVendedores.DataBind();
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        Usuario U;
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

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            Session["Accion"] = "Agregar";
            Response.Redirect("FormABMVendedor.aspx", false);
        }

        protected void BtnVer_Click(object sender, EventArgs e)
        {
            Button BTNVer = (Button)sender;
            GridViewRow Row = (GridViewRow)BTNVer.NamingContainer;
            string ID = Row.Cells[1].Text;
            Session["IDRow"] = ID;
            Session["Accion"] = "Ver";
            Response.Redirect("FormABMVendedor.aspx", false);
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Button BTNVer = (Button)sender;
            GridViewRow Row = (GridViewRow)BTNVer.NamingContainer;
            string ID = Row.Cells[1].Text;
            Session["IDRow"] = ID;
            Session["Accion"] = "Modificar";
            Response.Redirect("FormABMVendedor.aspx", false);
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            Button BTNVer = (Button)sender;
            GridViewRow Row = (GridViewRow)BTNVer.NamingContainer;
            string ID = Row.Cells[1].Text;
            Session["IDRow"] = ID;
            Session["Accion"] = "Eliminar";
            Response.Redirect("FormABMVendedor.aspx", false);
        }
    }
}