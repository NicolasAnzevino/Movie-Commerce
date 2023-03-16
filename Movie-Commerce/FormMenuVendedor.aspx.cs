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
    public partial class FormMenuVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL_Usuario = new BLL_Usuario();

            if (Session["Usuario"] != null)
            {
                U = (Usuario)Session["Usuario"];
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

        Usuario U;
        BLL_Usuario BLL_Usuario;
        public List<LinkButton> Botones = new List<LinkButton>();

        public void SetActionControls()
        {
            ACGestionProductos.Button1.Text = "Gestion Películas";
            ACGestionProductos.Image1.ImageUrl = "https://thumbs.dreamstime.com/b/sistema-plano-del-estilo-del-vector-del-viejo-icono-del-cine-para-las-pel%C3%ADculas-en-l%C3%ADnea-79693139.jpg";
            ACGestionProductos.Button1.Click += ACGestionPeliculas_Click;
            ACGestionProductos.Button1.CommandName = "Gestion Peliculas";

            ACVerVentas.Button1.Text = "Ver Ventas";
            ACVerVentas.Image1.ImageUrl = "https://thumbs.dreamstime.com/b/sistema-plano-del-estilo-del-vector-del-viejo-icono-del-cine-para-las-pel%C3%ADculas-en-l%C3%ADnea-79693139.jpg";
            ACVerVentas.Button1.Click += ACVerVentas_Click;
            ACVerVentas.Button1.CommandName = "Ver Ventas";

            ACVerPeliculasMasVendidas.Button1.Text = "Ver Películas más vendidas";
            ACVerPeliculasMasVendidas.Image1.ImageUrl = "https://thumbs.dreamstime.com/b/sistema-plano-del-estilo-del-vector-del-viejo-icono-del-cine-para-las-pel%C3%ADculas-en-l%C3%ADnea-79693139.jpg";
            ACVerPeliculasMasVendidas.Button1.Click += ACVerPeliculasMasVendidas_Click;
            ACVerPeliculasMasVendidas.Button1.CommandName = "Ver Películas más vendidas";
        }

        private void ACVerPeliculasMasVendidas_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormVerPeliculasMasVendidas.aspx", false);
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        private void ACVerVentas_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormVerVentas.aspx", false);
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        #region Eventos de AC

        private void ACGestionPeliculas_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormGestionPeliculas.aspx", false);
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        #endregion

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
    }
}