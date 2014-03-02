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
            var userInfo = _authenticator.RegisterNewUser(user, email, password);

            //User is logged in
            Session["userID"] = userInfo.UserID;
            Session["username"] = userInfo.Username;
            Response.Redirect("mainPage.aspx");
        }
    }
}