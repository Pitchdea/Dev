using System;
using System.Web.UI;
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
            
            if (passwordTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type a password.";
                return;
            }

            var userInfo = _auth.Authenticate(emailTextBox.Text, passwordTextBox.Text);
            
            if (userInfo != null)
            {
                Session["userID"] = userInfo.UserId;
                Session["username"] = userInfo.Username;
                Response.Redirect("mainPage.aspx");
            }
            else
            {
                errorMessage.Text = "Email/username and password don't match.";
            }
        }
    }
}