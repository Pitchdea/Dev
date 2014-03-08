using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Controls;
using Pitchdea.Core;
using Pitchdea.Core.Model;

namespace Pitchdea
{
    public partial class CreateIdeaPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();
       
        public string UploadedImage
        {
            get
            {
                return (string)ViewState["UploadedImage"];
            }
            set { ViewState["UploadedImage"] = value; }
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
            if (Session["userId"] == null)
            {
                HideAll();
            }
            else
            {
                ShowAll();
            }

            errorMessage.Text = "";
            //var foo = ThumbnailCropControl;

            ////if (UploadedImage != null)// && !ThumbnailCropControl.ThumbnailSelected)
            ////{
            //    ShowImageThumbnailCropper();
            ////}
            ////else
            ////{
            //    //HideImageThumbnailCropper();
            //    if (ThumbnailCropControl.ThumbnailSelected)
            //    {
            //        uploadStatusLabel.Text = "Your image was uploaded successfully.";
            //        LoadPreviewImage();
            //    }
            //}
            if (UploadedImage == null)
                cropControl.Visible = false;

            if (cropControl.ThumbnailSelected)
            {
                cropControl.Visible = false;
                LoadPreviewImage();
            }

            cropControl.ThumbSelected += () =>
            {
                cropControl.Visible = false;
                uploadStatusLabel.Text = "Your image was uploaded successfully.";
                LoadPreviewImage();
            };
        }

        private void ShowAll()
        {
            createIdeaPanel.Visible = true;
            loginFirstPanel.Visible = false;
        }

        private void HideAll()
        {
            createIdeaPanel.Visible = false;
            loginFirstPanel.Visible = true;
        }

        private void LoadPreviewImage()
        {
            previewImage.Visible = false;
            if (UploadedImage != null)
            {
                //TODO: maybe show both preview of uploaded image and preview of cropped thumbnail?
                var ext = Path.GetExtension(UploadedImage);
                string thumb = UploadedImage.Split(new [] {'.'}).First() + "_thumb" + ext;
                previewImage.ImageUrl = SavePath + thumb;
                previewImage.Width = 100;
                previewImage.Height = 64;
                previewImage.Visible = true;
            }
        }

        protected void createIdeaButton_OnClick(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var summary = summaryTextBox.Text;
            var description = descriptionTextBox.Text;
            var question = questionTextBox.Text;
            var ownerId = Session["userId"];

            if (string.IsNullOrWhiteSpace(title))
            {
                errorMessage.Text = "The idea title is missing.";
                return;
            }

            if (string.IsNullOrWhiteSpace(summary))
            {
                errorMessage.Text = "The idea summary is missing.";
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                errorMessage.Text = "The idea description is missing.";
                return;
            }

            if (string.IsNullOrWhiteSpace(question))
            {
                errorMessage.Text = "The idea question is missing.";
                return;
            }

            if (title.Length > 70)
            {
                errorMessage.Text = "The title is too long, the maximum length is 70 characters.";
                return;
            }

            if (summary.Length > 200)
            {
                errorMessage.Text = "The summary is too long, the maximum length  is 200 characters.";
                return;
            }

            if (description.Length > 1500)
            {
                errorMessage.Text = "The description is too long, the maximum length is 1500 characters.";
                return;
            }

            if (question.Length > 90)
            {
                errorMessage.Text = "The question is too long, the maximum length is 90 characters.";
                return;
            }

            if (ownerId == null)
                throw new Exception();

            var idea = new Idea((int)ownerId, title, summary, description, question){ImagePath = UploadedImage};

            var insertedIdea = _sqlTool.InsertIdea(idea);

            Response.Redirect("viewIdeaPage.aspx?ID=" + insertedIdea.Hash);
        }

        protected void uploadImageButton_OnClick(object sender, EventArgs e)
        {
            // Verify that the ImgUpload controller has the file.
            if (!ImgUpload.HasFile)
            {
                // Notify the user their file was not uploaded.
                uploadStatusLabel.Text = "Oops! You forgot to specify an image to upload.";
                return;
            }

            // Set filesize limit.
            if (ImgUpload.PostedFile.ContentLength >= 512000)
            {
                // Notify the user their file was too big.
                uploadStatusLabel.Text = "Oops! Your image was bigger than the maximum 500kB.";
                return;
            }

            // Allow only .jpg files to be uploaded. TODO: This is still not safe, attacker could circumwent by renaming their malicious file.
            if (Path.GetExtension(ImgUpload.FileName) != ".jpg")
            {
                uploadStatusLabel.Text = "Oops! Your file was not a .jpg image.";
                return;
            }

            //TODO: Resize the file, 300px*300px perhaps?
            // Gets the current long UTC time with milliseconds. 
            string timeNow = DateTime.UtcNow.ToString("yyyyMMddHHmmssffff");

            // Gets the extension of the file.
            string fExtension = Path.GetExtension(ImgUpload.PostedFile.FileName);
            // Ads the milliseconds and the file extension to the filename.
            var ownerId = Session["userId"];
            if (ownerId == null)
                throw new Exception("User is not logged in.");
            string fileName = ownerId + timeNow + fExtension;

            // Gets the file upload location.
            string imgLocation = Server.MapPath(SavePath + fileName);
            // Renames and saves the image to the specified path. If a file with the same name already exists it will be overwritten.
            ImgUpload.SaveAs(imgLocation);
            
            // Notify the user their file was uploaded successfully.
            UploadedImage = fileName;
            
            //ShowImageThumbnailCropper();
            cropControl.Image = fileName;
            cropControl.UpdateImage();
            cropControl.Visible = true;
        }

        //private void ShowImageThumbnailCropper()
        //{
        //    if (UploadedImage != null)
        //    {
        //        ThumbnailCropControl.Image = UploadedImage;
        //        ThumbnailCropControl.Visible = true;
        //        thumbnailControlPlaceholder.Controls.Add(ThumbnailCropControl);
        //    }
        //    else
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //private void HideImageThumbnailCropper()
        //{
        //    ThumbnailCropControl.Visible = false;
        //}
    }
}
