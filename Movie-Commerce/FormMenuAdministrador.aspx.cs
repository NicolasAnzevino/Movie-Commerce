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
    public partial class FormMenuAdministrador : System.Web.UI.Page
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
                SetActionControls();
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        Usuario U;
        BLL_Usuario BLL_Usuario;
        public List<LinkButton> Botones = new List<LinkButton>();

        public void SetActionControls()
        {
            ACGestionVendedores.Button1.Text = "Gestion Vendedores";
            ACGestionVendedores.Image1.ImageUrl = "https://us.123rf.com/450wm/ohorodniichuk/ohorodniichuk1705/ohorodniichuk170500353/77345766-ilustraci%C3%B3n-vectorial-de-vendedor-de-icono-plano-de-entradas-de-cine.jpg";
            ACGestionVendedores.Button1.Click += ACAgregarVendedor_Click;
            ACGestionVendedores.Button1.CommandName = "Gestion Vendedores";
        }

        #region Eventos de AC

        private void ACAgregarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormGestionVendedores.aspx", false);
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }      

        #endregion


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
    }
}