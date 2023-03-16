using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;
using System.IO;

namespace Movie_Commerce
{
    public partial class FormVerPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                BLL_Usuario = new BLL_Usuario();
                BLL_Pelicula = new BLL_Pelicula();

                if (Session["Mode"] != null)
                {
                    if (Session["Mode"].ToString() != "Carrito")
                    {
                        Palanca = false;
                    }
                    else
                    {
                        Palanca = true;
                    }

                    if (Palanca == true)
                    {
                        btnAgregarAlCarrito.Visible = false;
                    }
                    else
                    {
                        btnAgregarAlCarrito.Visible = true;
                    }
                }               

                U = (Usuario)Session["Usuario"];

                if (U == null)
                {
                    throw new Exception("No se ha ingresado con un usuario");
                }

                Pelicula_Seleccionada = BLL_Pelicula.Obtener_Pelicula(int.Parse(Session["IDPel"].ToString()));

                if (!Page.IsPostBack)
                {
                    if (lbGenerosPelicula.Items.Count > 0)
                    {
                        lbGenerosPelicula.Items.Clear();
                    }

                    if (Generos.Count > 0)
                    {
                        Generos = new List<Genero>();
                    }

                    if (MisGeneros.Count > 0) //Nota: Al ser estatico, se mantienen la de las otras peliculas..
                    {
                        MisGeneros = new List<Genero>();
                    }

                    Generos = BLL_Pelicula.Ver_Generos();
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
                }

                lblTitulo.Text = "Ver Película";
                FileUploadImagen.Visible = false;

                TextBoxID.Text = Pelicula_Seleccionada.Codigo.ToString();
                TextBoxNombre.Text = Pelicula_Seleccionada.Nombre.ToString();
                TextBoxDescripcion.Text = Pelicula_Seleccionada.Descripcion.ToString();
                TextBoxPrecio.Text = Pelicula_Seleccionada.Precio.ToString();

                TextBoxID.Enabled = false;
                TextBoxNombre.Enabled = false;
                TextBoxDescripcion.Enabled = false;
                TextBoxPrecio.Enabled = false;

                string Imagen = "";

                Imagen = Convert.ToBase64String(Pelicula_Seleccionada.Imagen, 0, Pelicula_Seleccionada.Imagen.Length);
                Image1.ImageUrl = "data:image/png;base64," + Imagen;

                foreach (Genero genero in Pelicula_Seleccionada.Generos)
                {
                    MisGeneros.Add(new Genero(genero.Codigo, genero.Nombre));
                    Generos.Remove(Generos.Find(X => X.Codigo == genero.Codigo));
                }

                if (MisGeneros.Count > 0)
                {
                    lbGenerosPelicula.Items.Clear();
                    lbGenerosPelicula.DataSource = null;
                    lbGenerosPelicula.DataSource = MisGeneros;
                    lbGenerosPelicula.DataBind();
                    lbGenerosPelicula.SelectedIndex = 0;
                }
                else
                {
                    lbGenerosPelicula.Items.Clear();
                    lbGenerosPelicula.DataSource = null;                
                }
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

        bool Palanca = false;
        Usuario U;
        Pelicula Pelicula = new Pelicula();
        Pelicula Pelicula_Seleccionada;
        BLL_Usuario BLL_Usuario;
        BLL_Pelicula BLL_Pelicula;
        public List<LinkButton> Botones = new List<LinkButton>();
        public static List<Genero> Generos = new List<Genero>();
        public static List<Genero> MisGeneros = new List<Genero>(); //M
        public static int ID_Temporal;

        #region LinkButtons
        protected void linklblInicio_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormMainMenu.aspx");
        }
        protected void linklblVerProductos_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormVerProductos.aspx");
        }
        protected void linklblMenuAdministrador_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormMenuAdministrador.aspx");
        }

        protected void linklblMenuVendedor_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormMenuVendedor.aspx");
        }

        protected void linklblVerMisCompras_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormVerMisCompras.aspx");
        }

        protected void linklblCarrito_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormVerCarrito.aspx");
        }

        protected void linklblRegistrarse_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
            Response.Redirect("FormRegistrarse.aspx");
        }

        protected void linklblCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Mode"] = "A";
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (Palanca== true)
            {
                Session["Mode"] = "A";
                Response.Redirect("FormVerCarrito.aspx", false);
            }
            else
            {
                Response.Redirect("FormMainMenu.aspx", false);
            }
        }

        public byte[] ImageControlToByteArray(Image image)
        {
            try
            {
                // Attempt to find the Image that the control points to
                // and read all of it's bytes
                return File.ReadAllBytes(Server.MapPath(image.ImageUrl));
            }
            catch (Exception ex)
            {
                // Uh oh, there was a problem reading the file
                return new byte[0];
            }
        }
    }
}