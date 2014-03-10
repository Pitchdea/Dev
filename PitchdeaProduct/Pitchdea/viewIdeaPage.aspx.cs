using System;
using System.Globalization;
using System.Web.UI;
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

            if (idea == null)
            {
                titleLabel.Visible = false;
                summaryLabel.Visible = false;
                descriptionLabel.Visible = false;
                questionLabel.Visible = false;
                ideaOwnerPanel.Visible = false;
                ideaImage.Visible = false;
                return;
            }

            ideaNotFoundPanel.Visible = false;

            Title = idea.Title + " | Pitchdea";
            titleLabel.Text = idea.Title;

            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            var imagePath = config.AppSettings.Settings["savePath"].Value;

            if (!string.IsNullOrWhiteSpace(idea.ImagePath)) //Use custom image submitted by the user.
            {
                ideaImage.ImageUrl = imagePath + idea.ImagePath;
            }
            else
            {
                ideaImage.ImageUrl = "img/ideaImages/defaultIdeaImage.jpg";
            }

            summaryLabel.Text = idea.Summary.Replace(Environment.NewLine, "<br />");
            descriptionLabel.Text = idea.Description.Replace(Environment.NewLine, "<br />");
            questionLabel.Text = idea.Question.Replace(Environment.NewLine, "<br />");
            ideaOwner.Text = _sqlTool.FindUsername(idea.UserId);
            ideaLikeLabel.Text = idea.Likes.ToString(CultureInfo.InvariantCulture);
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }
    
    }
}