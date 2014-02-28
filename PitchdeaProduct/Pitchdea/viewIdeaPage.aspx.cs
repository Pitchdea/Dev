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
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            var idea = FindIdea();
            Title = idea.Title + " | Pitchdea";
            titleLabel.Text = idea.Title;
            summaryLabel.Text = idea.Summary;
            descriptionLabel.Text = idea.Description;
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }
    
    }
}