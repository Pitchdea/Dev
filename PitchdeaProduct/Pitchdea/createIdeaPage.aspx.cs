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
    public partial class CreateIdeaPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createIdeaButton_OnClick(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var summary = summaryTextBox.Text;
            var description = descriptionTextBox.Text;
            var ownerId = Session["userId"];

            if (ownerId == null)
                throw new Exception();

            var idea = new Idea((int) ownerId, title, summary, description);

            var insertedIdea = _sqlTool.InsertIdea(idea);

            Response.Redirect("viewIdeaPage.aspx?ID=" + insertedIdea.Hash);
        }
    }
}