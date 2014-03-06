using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Core;

namespace Pitchdea
{
    public partial class MainPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            //var ideas = _sqlTool.FetchAllIdeas();
        }
    }
}