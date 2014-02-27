using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Core;
using Pitchdea.Core.Model;

namespace Pitchdea
{
    public partial class ViewIdeaPage : Page
    {
        private readonly ISqlTool _sqlTool = new MySqlTool("");

        protected void Page_Load(object sender, EventArgs e)
        {
            var idea = FindIdea();
            Title = idea.Title + " | Pitchdea";
        }

        private Idea FindIdea()
        {
            string ideaHash = Request.Form["ID"];
            var idea = _sqlTool.FetchIdea(ideaHash);

            throw new NotImplementedException();
        }
    
    }
}