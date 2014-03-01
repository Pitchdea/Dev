using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pitchdea.Controls
{
    //TODO: What's the best way for testing with SpecFlow?
    public partial class LoginStatusControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object username = Session["username"];
            if (username != null)
            {
                activeUserLabel.Text = username.ToString();
                logoutLink.Visible = true;
            }
            else
            {
                loginLink.Visible = true;
            }
        }
    }
}