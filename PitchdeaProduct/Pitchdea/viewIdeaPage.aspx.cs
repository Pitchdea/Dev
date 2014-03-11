﻿using System;
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
            switch (_sqlTool.GetLikeStatus(_idea.Id, _userId))
            {
                case LikeStatus.Neutral:
                    noButton.CssClass = "nobutton";
                    _sqlTool.Dislike(_idea.Id, _userId);
                    break;
                case LikeStatus.Dislike:
                    noButton.CssClass = "disliked";
                    _sqlTool.Undislike(_idea.Id, _userId);
                    break;
                case LikeStatus.Like:
                    noButton.CssClass = "nobutton";
                    //TODO: Performance issues?
                    var likes = _sqlTool.Unlike(_idea.Id, _userId);
                    ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                    _sqlTool.Dislike(_idea.Id, _userId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected void yesButton_OnClick(object sender, EventArgs e)
        {
            switch (_sqlTool.GetLikeStatus(_idea.Id, _userId))
            {
                case LikeStatus.Neutral:
                    {
                        yesButton.CssClass = "yesbutton";
                        var likes = _sqlTool.Like(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                    }
                    break;
                case LikeStatus.Like:
                    {
                        yesButton.CssClass = "liked";
                        var likes = _sqlTool.Unlike(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                    }
                    break;
                case LikeStatus.Dislike:
                    {
                        yesButton.CssClass = "yesbutton";
                        //TODO: Performance issues?
                        _sqlTool.Undislike(_idea.Id, _userId);
                        var likes = _sqlTool.Like(_idea.Id, _userId);
                        ideaLikeLabel.Text = likes.ToString(CultureInfo.InvariantCulture);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}