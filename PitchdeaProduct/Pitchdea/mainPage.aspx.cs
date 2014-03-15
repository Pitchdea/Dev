using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Pitchdea.Core;

namespace Pitchdea
{
    public partial class MainPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            var ideas = _sqlTool.FetchAllIdeas();
            ideas.Reverse();
            foreach (var idea in ideas)
            {
                var hyperLink = new HyperLink
                {
                    NavigateUrl = "viewIdeaPage.aspx?ID=" + idea.Hash,
                    CssClass = "idea"
                };

                var inner = new Panel();
                inner.CssClass = "ideabox";

                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var imagePath = config.AppSettings.Settings["savePath"].Value;

                string imageUrl;
                if (!string.IsNullOrWhiteSpace(idea.ImagePath)) //Use custom image submitted by the user.
                {
                    var ext = Path.GetExtension(idea.ImagePath);
                    string thumb = idea.ImagePath.Split(new[] { '.' }).First() + "_thumb" + ext;
                    imageUrl = imagePath + thumb;
                }
                else
                {
                    imageUrl = "img/ideaImages/defaultIdeaImage_thumb.jpg";
                }

                inner.Controls.Add(new Image
                {
                    ImageUrl = imageUrl
                });
                inner.Controls.Add(new HtmlGenericControl("h4")
                {
                    InnerHtml = idea.Title
                });
                inner.Controls.Add(new HtmlGenericControl("p")
                {
                    InnerHtml = idea.Summary
                });

                hyperLink.Controls.Add(inner);
                ideaPanel.Controls.Add(hyperLink);
            }
        }
    }
}