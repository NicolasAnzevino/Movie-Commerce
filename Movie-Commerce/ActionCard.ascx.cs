using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Commerce
{
    public partial class ActionCard : System.Web.UI.UserControl
    {
        public ActionCard()
        {
            Button1 = new Button();
            Image1 = new Image();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Text = Button1.Text;
        }
    }
}