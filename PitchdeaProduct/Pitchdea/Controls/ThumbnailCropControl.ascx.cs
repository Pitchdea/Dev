using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageResizer;

namespace Pitchdea.Controls
{
    public partial class ThumbnailCropControl : System.Web.UI.UserControl
    {
        public string Image { get; set; }

        private static string SavePath
        {
            get
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var savePath = config.AppSettings.Settings["savePath"].Value;
                return savePath;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            uploadedImage.ImageUrl = SavePath + Image;
        }

        protected void doneButton_OnClick(object sender, EventArgs e)
        {
            var path = img.Value.Split(new [] {'?'}).First();
            var fileNameWithoutExtension = Image.Split(new [] {'.'}).First();

            ImageBuilder.Current.Build(
                ResolveUrl(ImageResizer.Util.PathUtils.RemoveQueryString(Server.MapPath(path))),
                Server.MapPath("~/img/ideaImages/uploaded/"+ fileNameWithoutExtension + "_thumb.jpg"),
                new ResizeSettings(img.Value+@"&width=250&height=160"));
        }
    }
}