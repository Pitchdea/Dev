using System;
using System.Web.UI;
using Pitchdea.Core;
using Pitchdea.Core.Model;

namespace Pitchdea
{
    public partial class EditIdeaPage : Page
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

            if (!string.IsNullOrWhiteSpace(_idea.ImagePath)) //Use custom image submitted by the user.
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var imagePath = config.AppSettings.Settings["savePath"].Value;
                ideaImage.ImageUrl = imagePath + _idea.ImagePath;
            }
            else
            {
                ideaImage.ImageUrl = "img/ideaImages/defaultIdeaImage.jpg";
            }


            if (!IsPostBack)
            {
                ideaTitleTextBox.Text = _idea.Title;
                ideaSummaryTextBox.Text = _idea.Summary;
                ideaDescriptionTextBox.Text = _idea.Description;
                ideaQuestionTextBox.Text = _idea.Question;
            }
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }

        protected void submitChangesButton_OnClick(object sender, EventArgs e)
        {
            _idea.Title = ideaTitleTextBox.Text;
            _idea.Summary = ideaSummaryTextBox.Text;
            _idea.Description = ideaDescriptionTextBox.Text;
            _idea.Question = ideaQuestionTextBox.Text;
            _sqlTool.UpdateIdea(_idea);
            Response.Redirect("viewIdeaPage.aspx?ID=" + _idea.Hash);
        }
    }
}