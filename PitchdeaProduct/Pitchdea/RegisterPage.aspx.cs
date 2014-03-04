using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Core;

namespace Pitchdea
{
    public partial class RegisterPage : Page
    {
        private readonly IAuthenticator _authenticator = AuthenticatorFactory.CreateNew();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void registerButton_OnClick(object sender, EventArgs e)
        {
            var user = usernameTextBox.Text;
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;
            
            if (emailTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type an email.";
                return;
            }
            if (!EmailValidator.IsValid(emailTextBox.Text))
            {
                errorMessage.Text = "This doesn't seem to be an email address.";
            }

            if (passwordTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type a password.";
                return;
            }

            if (usernameTextBox.Text == string.Empty)
            {
                errorMessage.Text = "You forgot to type a username.";
                return;
            }

            if (passwordTextBox.Text != passwordConfirmationTextBox.Text)
            {                            
                errorMessage.Text = "The passwords do not match.";
                return;
            }

            if (_authenticator.CheckIfUsernameExists(user))
            {
                errorMessage.Text = "Oops! That username has already been taken";
                return;
            }

            if (_authenticator.CheckIfEmailExists(email))
            {
                errorMessage.Text = "Oops! That email is already in use";
                return;
            }

            var userInfo = _authenticator.RegisterNewUser(user, email, password);

            //User is logged in
            Session["userID"] = userInfo.UserID;
            Session["username"] = userInfo.Username;
            Response.Redirect("mainPage.aspx");
        }
    }
}