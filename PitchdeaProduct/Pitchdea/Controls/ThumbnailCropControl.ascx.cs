using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}