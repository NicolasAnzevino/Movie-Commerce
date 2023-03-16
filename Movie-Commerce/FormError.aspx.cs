using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Commerce
{
    public partial class FormError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Error_desc.Text = Session["mensaje_error"].ToString();
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FormLogin.aspx", false);
            }
            catch (Exception ex) { Session["mensaje_error"] = ex.Message; Response.Redirect("Error.aspx"); }
        }
    }
}