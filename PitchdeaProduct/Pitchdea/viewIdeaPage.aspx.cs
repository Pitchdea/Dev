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
        private int _userId = -1;

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
                loggedIn.Text = string.Format("<input type='hidden' id='loggedIn' name='loggedInHidden' value='{0}' />", true);
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
                loggedIn.Text = string.Format("<input type='hidden' id='loggedIn' name='loggedInHidden' value='{0}' />", false);
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

            if (_userId == -1)
                return;

            switch (_sqlTool.GetLikeStatus(_idea.Id, _userId)) //User like status BEFORE the button is pressed
            {
                case LikeStatus.Neutral:
                    yesButton.CssClass = "yesbutton";
                    noButton.CssClass = "nobutton";
                    break;
                case LikeStatus.Like:
                    yesButton.CssClass = "liked";
                    noButton.CssClass = "nobutton";
                    break;
                case LikeStatus.Dislike:
                    yesButton.CssClass = "yesbutton";
                    noButton.CssClass = "disliked";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }

        protected void noButton_OnClick(object sender, EventArgs e)
        {
            if (_userId == -1)
                return;

            switch (_sqlTool.GetLikeStatus(_idea.Id, _userId)) //User like status BEFORE the button is pressed
            {
                case LikeStatus.Neutral:
                    _sqlTool.Dislike(_idea.Id, _userId);
                    noButton.CssClass = "disliked";
                    break;
                case LikeStatus.Dislike:
                    _sqlTool.Undislike(_idea.Id, _userId);
                    noButton.CssClass = "nobutton";
                    break;
                case LikeStatus.Like:
                    //TODO: Performance issues?
                    var likes = _sqlTool.Unlike(_idea.Id, _userId);
                    ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                    _sqlTool.Dislike(_idea.Id, _userId);
                    noButton.CssClass = "disliked";
                    yesButton.CssClass = "yesbutton";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected void yesButton_OnClick(object sender, EventArgs e)
        {
            if (_userId == -1)
                return;

            switch (_sqlTool.GetLikeStatus(_idea.Id, _userId)) //User like status BEFORE the button is pressed
            {
                case LikeStatus.Neutral:
                    {
                        var likes = _sqlTool.Like(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                        yesButton.CssClass = "liked";
                    }
                    break;
                case LikeStatus.Like:
                    {
                        var likes = _sqlTool.Unlike(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                        yesButton.CssClass = "yesbutton";
                    }
                    break;
                case LikeStatus.Dislike:
                    {
                        //TODO: Performance issues?
                        _sqlTool.Undislike(_idea.Id, _userId);
                        var likes = _sqlTool.Like(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                        yesButton.CssClass = "liked";
                        noButton.CssClass = "nobutton";
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}