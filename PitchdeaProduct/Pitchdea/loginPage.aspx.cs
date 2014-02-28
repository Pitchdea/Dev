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
            _auth = new Authenticator(SqlToolFactory.ConnectionString);
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {
            if (emailTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type an email.";
                return;
            }

            if (!EmailValidator.Validate(emailTextBox.Text))
            {
                errorMessage.Text = "This doesn't seem to be an email address.";
                return;
            }

            if (passwordTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type a password.";
                return;
            }

            var userId = _auth.Authenticate(emailTextBox.Text, passwordTextBox.Text);
            
            if (userId != -1)
            {
                Session["userID"] = userId;
                Session["username"] = emailTextBox.Text.ToLower();
                Response.Redirect("mainPage.aspx");
            }
            else
            {
                errorMessage.Text = "Email and password combination is incorrect.";
            }
        }
    }
}