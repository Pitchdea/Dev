using System;
using System.Web.UI;

namespace Pitchdea
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/mainPage.aspx");
        }
    }
}