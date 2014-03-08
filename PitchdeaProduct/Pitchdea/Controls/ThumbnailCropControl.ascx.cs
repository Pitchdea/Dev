using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ImageResizer;

namespace Pitchdea.Controls
{
    public partial class ThumbnailCropControl : System.Web.UI.UserControl
    {
        public string Image {
            get { return (string) ViewState["Image"]; }
            set { ViewState["Image"] = value; }
        }

        private static string SavePath
        {
            get
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var savePath = config.AppSettings.Settings["savePath"].Value;
                return savePath;
            }
        }

        public bool ThumbnailSelected
        {
            get
            {
                if (ViewState["ThumbnailSelected"] != null)
                    return (bool)ViewState["ThumbnailSelected"];
                return false;
            }
            set { ViewState["ThumbnailSelected"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doneButton_OnClick(object sender, EventArgs e)
        {
            var path = img.Value.Split(new [] {'?'}).First();
            var fileNameWithoutExtension = Image.Split(new [] {'.'}).First();

            ImageBuilder.Current.Build(
                ResolveUrl(ImageResizer.Util.PathUtils.RemoveQueryString(Server.MapPath(path))),
                Server.MapPath("~/img/ideaImages/uploaded/"+ fileNameWithoutExtension + "_thumb.jpg"),
                new ResizeSettings(img.Value+@"&width=250&height=160"));

            ThumbnailSelected = true;
            ThumbSelected();
        }

        public delegate void Foo();
        public event Foo ThumbSelected;

        public void UpdateImage()
        {
            uploadedImage.ImageUrl = SavePath + Image;
            System.Drawing.Image fromFile = System.Drawing.Image.FromFile(Server.MapPath(SavePath + Image));
            int width = fromFile.Width;
            int height = fromFile.Height;

            if (width > 350)
            {
                uploadedImage.Width = 350;
                uploadedImage.Height = Unit.Pixel(Convert.ToInt32(height * (350f / width)));
            }
        }
    }
}