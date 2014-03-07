using System;
using System.Web.UI;

namespace Pitchdea.Controls
{
    public partial class LoginStatusControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loginLink.Visible = false;
            logoutLink.Visible = false;
            activeUserLabel.Visible = false;
            registerLink.Visible = false;
            loggedInAsLabel.Visible = false;

            object username = Session["username"];
            if (username != null)
            {
                if (Session["userID"] == null)
                    throw new Exception("Username found in sessions variable but no user ID.");

                activeUserLabel.Text = username.ToString();
                activeUserLabel.Visible = true;
                logoutLink.Visible = true;
                loggedInAsLabel.Visible = true;
            }
            else
            {
                loginLink.Visible = true;
                registerLink.Visible = true;
            }
        }

        protected void logoutLink_OnClick(object sender, EventArgs e)
        {
            Session.Remove("userID");
            Session.Remove("username");
            Page_Load(this, null);
        }

        protected void registerLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/registerPage.aspx?url=" + Request.Url);
        }

        protected void loginLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/loginPage.aspx?url=" + Request.Url);
        }
    }
}