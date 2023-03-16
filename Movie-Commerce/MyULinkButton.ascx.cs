using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Commerce
{
    public partial class MyULinkButton : System.Web.UI.UserControl
    {
        public MyULinkButton()
        {
            Lista = new List<string>();
            this.LinkButton = new LinkButton();
            LB = this.LinkButton;
        }

        public LinkButton LB { get; set; }

        public List<string> Lista { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}