using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pitchdea
{
    public partial class MainPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var username = Session["username"];
            if (username != null)
            {
                activeUserLabel.Text = username.ToString();
            }
            else
            {
                
            }
        }
    }
}