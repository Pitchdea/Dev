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
    public partial class EditIdeaPage : System.Web.UI.Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();
        private Idea _idea;

        protected void Page_Load(object sender, EventArgs e)
        {
            _idea = FindIdea();

            if (_idea == null)
            {
                return;
            }

            Title = _idea.Title + " | Pitchdea";
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }
    }
}