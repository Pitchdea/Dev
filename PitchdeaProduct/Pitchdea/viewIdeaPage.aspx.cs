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
        private Idea _idea;
        private int _userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _idea = FindIdea();
            _userId = (int)Session["userId"];

            if (_idea == null)
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

            Title = _idea.Title + " | Pitchdea";
            titleLabel.Text = _idea.Title;

            var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            var imagePath = config.AppSettings.Settings["savePath"].Value;

            if (!string.IsNullOrWhiteSpace(_idea.ImagePath)) //Use custom image submitted by the user.
            {
                ideaImage.ImageUrl = imagePath + _idea.ImagePath;
            }
            else
            {
                ideaImage.ImageUrl = "img/ideaImages/defaultIdeaImage.jpg";
            }

            summaryLabel.Text = _idea.Summary.Replace(Environment.NewLine, "<br />");
            descriptionLabel.Text = _idea.Description.Replace(Environment.NewLine, "<br />");
            questionLabel.Text = _idea.Question.Replace(Environment.NewLine, "<br />");
            ideaOwner.Text = _sqlTool.FindUsername(_idea.UserId);
            ideaLikeLabel.Text = _idea.Likes.ToString(CultureInfo.InvariantCulture);
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }

        protected void noButton_OnClick(object sender, EventArgs e)
        {
            //TODO
            //int likes = _sqlTool.Like(_idea.Id, _userId);
            //ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
        }
    }
}