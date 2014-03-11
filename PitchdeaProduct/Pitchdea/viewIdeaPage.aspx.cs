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

            if (_idea == null)
            {
                ideaPanel.Visible = false;
                return;
            }

            if (Session["userId"] != null)
            {
                _userId = (int) Session["userId"];
                if (_userId == _idea.UserId)
                {
                    //User is the idea owner
                }
                else
                {
                    //User is logged in but is not the owner
                }
            }
            else
            {
                //User is not logged in
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
            if (_sqlTool.GetLikeStatus(_idea.Id, _userId) == LikeStatus.Neutral)
            {
                _sqlTool.Dislike(_idea.Id, _userId);
            }
            else if (_sqlTool.GetLikeStatus(_idea.Id, _userId) == LikeStatus.Dislike)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        protected void yesButton_OnClick(object sender, EventArgs e)
        {
            if (_sqlTool.GetLikeStatus(_idea.Id, _userId) == LikeStatus.Neutral)
            {
                int likes = _sqlTool.Like(_idea.Id, _userId);
                ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
            }
            else if (_sqlTool.GetLikeStatus(_idea.Id, _userId) == LikeStatus.Like)
            {
                int likes = _sqlTool.Unlike(_idea.Id, _userId);
                ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}