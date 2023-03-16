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
    public partial class FormABMPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                BLL_Usuario = new BLL_Usuario();
                BLL_Pelicula = new BLL_Pelicula();

                U = (Usuario)Session["Usuario"];

                if (U == null)
                {
                    throw new Exception("No se ha ingresado con un usuario");
                }

                if (Session["Accion"].ToString() != "Agregar")
                {
                    Pelicula_Seleccionada = BLL_Pelicula.Obtener_Pelicula(int.Parse(Session["IDRow"].ToString()));
                }

                if (!Page.IsPostBack)
                {
                    if (lbGenerosPelicula.Items.Count > 0)
                    {
                        lbGenerosPelicula.Items.Clear();
                    }

                    if (lbGenerosPelicula0.Items.Count > 0)
                    {
                        lbGenerosPelicula0.Items.Clear();
                    }

                    if (Generos.Count> 0)
                    {
                        Generos = new List<Genero>();
                    }

                    if (MisGeneros.Count>0) //Nota: Al ser estatico, se mantienen la de las otras peliculas..
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
                    SetFormMode(Session["Accion"].ToString());

                    lbGenerosPelicula0.Items.Clear();
                    lbGenerosPelicula0.DataSource = null;
                    lbGenerosPelicula0.DataSource = Generos;
                    lbGenerosPelicula0.DataBind();

                    if (Session["Accion"].ToString() == "Agregar")
                    {
                        ID_Temporal = BLL_Pelicula.Insertar_Pelicula_Temporal();
                        TextBoxID.Text = ID_Temporal.ToString();
                    }
                }

                //if (lbGenerosPelicula.Items.Count > 0)
                //{
                //    lbGenerosPelicula.SelectedIndex = 0;
                //}

                //lbGenerosPelicula0.SelectedIndex = 0;

                //Esto es para que se muestre la imagen a la hora de seleccionar una
                if (IsPostBack && FileUploadImagen.PostedFile != null)
                {
                    if (FileUploadImagen.PostedFile.FileName.Length > 0)
                    { 
                        FileUploadImagen.SaveAs(Server.MapPath("~/Images/") + FileUploadImagen.PostedFile.FileName);
                        Image1.ImageUrl = "~/Images/" + FileUploadImagen.PostedFile.FileName;
                    }
                }
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("FormError.aspx"); }
        }

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (lbGenerosPelicula0.Items.Count>0)
            {
                //Agregar

                Genero G = Generos.Find(X => X.Nombre == lbGenerosPelicula0.SelectedValue.ToString());
                
                if (G != null)
                {
                    MisGeneros.Add(G);
                    Generos.Remove(G);
                }
;

                if (Generos.Count > 0)
                {
                    lbGenerosPelicula0.DataSource = null;
                    lbGenerosPelicula0.DataSource = Generos;
                    lbGenerosPelicula0.DataBind();
                    lbGenerosPelicula0.SelectedIndex = 0;
                }

                if (MisGeneros.Count > 0)
                {
                    lbGenerosPelicula.DataSource = null;
                    lbGenerosPelicula.DataSource = MisGeneros;
                    lbGenerosPelicula.DataBind();
                    lbGenerosPelicula.SelectedIndex = 0;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (lbGenerosPelicula.Items.Count>0)
            {
                //Quitar

                Genero G = MisGeneros.Find(X => X.Nombre == lbGenerosPelicula.SelectedValue.ToString());
                Generos.Add(G);
                Generos.Sort(Genero.Orden<Genero.OrdenNombre>());
                MisGeneros.Remove(G);

                if (Generos.Count>0)
                {
                    lbGenerosPelicula0.Items.Clear();
                    lbGenerosPelicula0.DataSource = null;
                    lbGenerosPelicula0.DataSource = Generos;
                    lbGenerosPelicula0.DataBind();
                    lbGenerosPelicula0.SelectedIndex = 0;
                }
                else
                {
                    lbGenerosPelicula0.Items.Clear();
                    lbGenerosPelicula0.DataSource = null;
                }

                if (MisGeneros.Count>0)
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
        }

        protected void btnAgregarPelicula_Click(object sender, EventArgs e)
        {
            switch (Session["Accion"].ToString())
            {
                case "Agregar":

                    if (TextBoxNombre.Text != "" && TextBoxPrecio.Text != "" && MisGeneros.Count > 0)
                    {
                        Pelicula.Codigo = ID_Temporal;
                        Pelicula.Nombre = TextBoxNombre.Text;
                        Pelicula.Descripcion = TextBoxDescripcion.Text;
                        Pelicula.Precio = decimal.Parse(TextBoxPrecio.Text);
                        Pelicula.Generos = MisGeneros;

                        if (!String.IsNullOrEmpty(Image1.ImageUrl)) //Si la pelicula posee una imagen cargada
                        {
                            Pelicula.Imagen = ImageControlToByteArray(Image1);
                            Pelicula.PoseeImagen = true;
                            //Pelicula.Imagen = new byte[FileUploadImagen.PostedFile.ContentLength];
                            //FileUploadImagen.PostedFile.InputStream.Read(Pelicula.Imagen, 0, FileUploadImagen.PostedFile.ContentLength);

                        }
                        else //En el caso de que no, le ponemos la predeterminada
                        {
                            FileStream Stream = new FileStream(@"D:\Carpeta Facultativa\Proyectos\Proyectos (ASP)\Movie-Commerce\Movie-Commerce\Recursos\default-movie.jpg", FileMode.Open, FileAccess.Read);
                            BinaryReader BR = new BinaryReader(Stream);
                            Pelicula.Imagen = BR.ReadBytes((int)Stream.Length);
                            Pelicula.PoseeImagen = false;
                        }

                        BLL_Pelicula.Agregar_Pelicula(Pelicula);
                        Response.Redirect("FormGestionPeliculas.aspx", false);
                    }

                    break;

                case "Eliminar":

                    BLL_Pelicula.Eliminar_Pelicula(Pelicula_Seleccionada);
                    Response.Write("<script type=text/javascript>alert('Pelicula eliminada correctamente.')</script>");
                    Response.Redirect("FormGestionPeliculas.aspx", false);

                    break;

                case "Modificar":

                    if (TextBoxNombre.Text != "" && TextBoxPrecio.Text != "" && MisGeneros.Count > 0)
                    {
                        Pelicula_Seleccionada.Nombre = TextBoxNombre.Text;
                        Pelicula_Seleccionada.Descripcion = TextBoxDescripcion.Text;
                        Pelicula_Seleccionada.Precio = decimal.Parse(TextBoxPrecio.Text);
                        Pelicula_Seleccionada.Generos = MisGeneros;

                        Pelicula_Seleccionada.Imagen = ImageControlToByteArray(Image1);

                        //if (Pelicula_Seleccionada.Imagen == 0)
                        //{

                        //}

                        if (!String.IsNullOrEmpty(Image1.ImageUrl)) //Si la pelicula posee una imagen cargada
                        {
                            Pelicula_Seleccionada.Imagen = ImageControlToByteArray(Image1);
                            //Pelicula_Seleccionada.Imagen = new byte[FileUploadImagen.PostedFile.ContentLength];
                            //FileUploadImagen.PostedFile.InputStream.Read(Pelicula_Seleccionada.Imagen, 0, FileUploadImagen.PostedFile.ContentLength);

                        }

                        if (Pelicula_Seleccionada.Imagen.Length == 0 && Pelicula_Seleccionada.PoseeImagen == true)
                        {
                            BLL_Pelicula.Modificar_Pelicula(Pelicula_Seleccionada, 0);
                        }
                        else if (Pelicula_Seleccionada.Imagen.Length == 0 && Pelicula_Seleccionada.PoseeImagen == false)
                        {
                            BLL_Pelicula.Modificar_Pelicula(Pelicula_Seleccionada, 0);
                        }
                        else if (Pelicula_Seleccionada.Imagen.Length != 0)
                        {
                            Pelicula_Seleccionada.PoseeImagen = true;
                            BLL_Pelicula.Modificar_Pelicula(Pelicula_Seleccionada, 1);
                        }

                        Response.Redirect("FormGestionPeliculas.aspx", false);
                    }

                    break;

                default:
                    break;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormGestionPeliculas.aspx", false);
        }

        public void SetFormMode(string pMode)
        {
            string Imagen;

            switch (pMode)
            {
                case "Ver":

                    lblTitulo.Text = "Ver Película";
                    btnRegistrarse.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = false;
                    lblTituloGeneros2.Visible = false;
                    lbGenerosPelicula0.Visible = false;
                    FileUploadImagen.Visible = false;

                    TextBoxID.Text = Pelicula_Seleccionada.Codigo.ToString();
                    TextBoxNombre.Text = Pelicula_Seleccionada.Nombre.ToString();
                    TextBoxDescripcion.Text = Pelicula_Seleccionada.Descripcion.ToString();
                    TextBoxPrecio.Text = Pelicula_Seleccionada.Precio.ToString();

                    TextBoxID.Enabled = false;
                    TextBoxNombre.Enabled = false;
                    TextBoxDescripcion.Enabled = false;
                    TextBoxPrecio.Enabled = false;

                    Imagen= Convert.ToBase64String(Pelicula_Seleccionada.Imagen, 0, Pelicula_Seleccionada.Imagen.Length);
                    Image1.ImageUrl = "data:image/png;base64," + Imagen;

                    foreach (Genero genero in Pelicula_Seleccionada.Generos)
                    {
                        MisGeneros.Add(new Genero(genero.Codigo, genero.Nombre));
                        Generos.Remove(Generos.Find(X=> X.Codigo == genero.Codigo));
                    }

                    if (MisGeneros.Count>0)
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

                    if (Generos.Count > 0)
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                        lbGenerosPelicula0.DataSource = Generos;
                        lbGenerosPelicula0.DataBind();
                        lbGenerosPelicula0.SelectedIndex = 0;
                    }
                    else
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                    }

                    break;

                case "Agregar":

                    btnRegistrarse.Text = "Agregar";
                    lblTitulo.Text = "Agregar Película";
                    TextBoxID.Enabled = false;
                    break;

                case "Modificar":

                    lblTitulo.Text = "Modificar Película";

                    btnRegistrarse.Text = "Modificar";

                    TextBoxID.Text = Pelicula_Seleccionada.Codigo.ToString();
                    TextBoxNombre.Text = Pelicula_Seleccionada.Nombre.ToString();
                    TextBoxDescripcion.Text = Pelicula_Seleccionada.Descripcion.ToString();
                    TextBoxPrecio.Text = Pelicula_Seleccionada.Precio.ToString();


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

                    if (Generos.Count > 0)
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                        lbGenerosPelicula0.DataSource = Generos;
                        lbGenerosPelicula0.DataBind();
                        lbGenerosPelicula0.SelectedIndex = 0;
                    }
                    else
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                    }
                    break;

                case "Eliminar":

                    lblTitulo.Text = "Eliminar Película";
                    btnRegistrarse.Text = "Eliminar";
                    Button1.Visible = false;
                    Button2.Visible = false;
                    lblTituloGeneros2.Visible = false;
                    lbGenerosPelicula0.Visible = false;
                    FileUploadImagen.Visible = false;

                    TextBoxID.Text = Pelicula_Seleccionada.Codigo.ToString();
                    TextBoxNombre.Text = Pelicula_Seleccionada.Nombre.ToString();
                    TextBoxDescripcion.Text = Pelicula_Seleccionada.Descripcion.ToString();
                    TextBoxPrecio.Text = Pelicula_Seleccionada.Precio.ToString();

                    TextBoxID.Enabled = false;
                    TextBoxNombre.Enabled = false;
                    TextBoxDescripcion.Enabled = false;
                    TextBoxPrecio.Enabled = false;

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

                    if (Generos.Count > 0)
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                        lbGenerosPelicula0.DataSource = Generos;
                        lbGenerosPelicula0.DataBind();
                        lbGenerosPelicula0.SelectedIndex = 0;
                    }
                    else
                    {
                        lbGenerosPelicula0.Items.Clear();
                        lbGenerosPelicula0.DataSource = null;
                    }

                    break;
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