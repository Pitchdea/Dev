using System;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Core;

namespace Pitchdea
{
    public partial class LoginPage : Page
    {
        private Authenticator _auth;

        protected void Page_Load(object sender, EventArgs e)
        {
            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            var connString = config.AppSettings.Settings["MySQL.ConnectionString"].Value;
            _auth = new Authenticator(connString);
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {
            var userId = _auth.Authenticate(emailTextBox.Text, passwordTextBox.Text);

            testLabel.Text = userId;

            if (userId != "-1")
            {
                Session["userID"] = userId;
                Session["username"] = emailTextBox.Text.ToLower();
                Response.Redirect("mainPage.aspx");
            }
            else
            {

            }
        }
    }
}