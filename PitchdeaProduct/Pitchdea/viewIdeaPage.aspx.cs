using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            
            LoadComments();

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

        protected void submitCommentButton_OnClick(object sender, EventArgs e)
        {
            if (_userId == -1)
                return;
            
            var comment = commentTextBox.Text;

            if (string.IsNullOrWhiteSpace(comment))
                return;

            _sqlTool.InsertComment(_idea.Id, _userId, comment);
            commentTextBox.Text = string.Empty;

            LoadComments();
        }

        private void LoadComments()
        {
            commentPanel.Controls.Clear();

            var comments = _sqlTool.FetchAllComments(_idea.Id);
            var i = 0;
            foreach (var comment in comments.OrderByDescending(n => n.SubmitTime))
            {
                i++;
                var submitter = _sqlTool.FindUsername(comment.UserId);

                //NOTE: The CssClass names are used in the automated tests, changing them will thus break the tests.
                //Also changes in the structure (elements and their relations) can cause tests to break.
                //If there is a need to change these, feel free to do so, tests can be updated. 
                //Either update the tests or notify Tero about the changes.

                var inner = new Panel {ID = "comment"+i, CssClass = "commentBox"};
                var commentLabel = new Label { Text = comment.Text, CssClass = "commentText" };
                var commentSubmitter = new Label { Text = submitter, CssClass = "commentSubmitter" };

                var timeAgo = DateTime.Now.Subtract(comment.SubmitTime);

                var commentTimestamp = new Label
                {
                    Text = (int)timeAgo.TotalMinutes + "minutes ago.", //TODO: scale the time: seconds - minutes - hours - days - weeks - months - years
                    CssClass = "commenttimeStamp"
                };

                inner.Controls.Add(commentLabel);
                inner.Controls.Add(commentSubmitter);
                inner.Controls.Add(commentTimestamp);

                commentPanel.Controls.Add(inner);
            }
        }
    }
}