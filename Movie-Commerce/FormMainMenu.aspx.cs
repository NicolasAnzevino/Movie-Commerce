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
    public partial class FormMainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL_Usuario = new BLL_Usuario();
            BLL_Pelicula = new BLL_Pelicula();

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

            Peliculas = BLL_Pelicula.Ver_Peliculas();

            string s = "";

            foreach (Pelicula pelicula in Peliculas)
            {
                //Explicación: PARA CAMBIAR DINAMICAMENTE EL VALOR DE UN CONTROL QUE TIENE UN CUSTOM CONTROL,
                //TENES QUE DECLARAR UNA VARIABLE DE ESE TIPO, APUNTAS A ESO Y LO CAMBIAS, GG
                PeliculaControl pc = (PeliculaControl)Page.LoadControl("PeliculaControl.ascx");

                //pc.Button1.Click += btnVer_Click;

                pc.lblTitulo = new Label();
                pc.lblTitulo.Text = pelicula.Nombre;
                Label A = (Label)pc.FindControl("lblTitulo");
                Label B = (Label)pc.FindControl("lblID");
                Image I = (Image)pc.FindControl("imgPelicula");
                s = Convert.ToBase64String(pelicula.Imagen, 0, pelicula.Imagen.Length);
                I.ImageUrl = "data:image/png;base64," + s;
                A.Text = pelicula.Nombre.ToString();
                B.Text = pelicula.Codigo.ToString();
                B.Visible = false;
                PlaceHolder1.Controls.Add(pc);
            }
            

        } //FIN FORM LOAD

        Usuario U;
        BLL_Usuario BLL_Usuario;
        BLL_Pelicula BLL_Pelicula;
        public List<LinkButton> Botones = new List<LinkButton>();
        public List<Pelicula> Peliculas;

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