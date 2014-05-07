using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using Pitchdea.Core;
using Pitchdea.Core.Model;

namespace Pitchdea
{
    public partial class EditIdeaPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();
        private Idea _idea;

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
            _idea = FindIdea();

            if (_idea == null)
            {
                return;
            }

            Title = _idea.Title + " | Pitchdea";

            if (!string.IsNullOrWhiteSpace(_idea.ImagePath)) //Use custom image submitted by the user.
            {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var imagePath = config.AppSettings.Settings["savePath"].Value;
                ideaImage.ImageUrl = imagePath + _idea.ImagePath;
            }
            else
            {
                ideaImage.ImageUrl = "img/ideaImages/defaultIdeaImage.jpg";
            }


            if (!IsPostBack)
            {
                ideaTitleTextBox.Text = _idea.Title;
                ideaSummaryTextBox.Text = _idea.Summary;
                ideaDescriptionTextBox.Text = _idea.Description;
                ideaQuestionTextBox.Text = _idea.Question;
            }

            previewImage.Visible = false;

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

        private Idea FindIdea()
        {
            string ideaHash = Request["ID"];
            return _sqlTool.FetchIdea(ideaHash);
        }

        protected void submitChangesButton_OnClick(object sender, EventArgs e)
        {
            var title = ideaTitleTextBox.Text;
            var summary = ideaSummaryTextBox.Text;
            var description = ideaDescriptionTextBox.Text;
            var question = ideaQuestionTextBox.Text;

            //TODO: IMPORTANT!! test automation for these!

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

            _idea.ImagePath = UploadedImage;
            _idea.Title = title;
            _idea.Summary = summary;
            _idea.Description = description;
            _idea.Question = question;
            _sqlTool.UpdateIdea(_idea);
            Response.Redirect("viewIdeaPage.aspx?ID=" + _idea.Hash);
        }

        private void LoadPreviewImage()
        {
            if (UploadedImage != null)
            {
                var ext = Path.GetExtension(UploadedImage);
                string thumb = UploadedImage.Split(new[] { '.' }).First() + "_thumb" + ext;
                previewImage.ImageUrl = SavePath + thumb;
                previewImage.Width = 100;
                previewImage.Height = 64;
                previewImage.Visible = true;

                string image = SavePath + UploadedImage;
                ideaImage.ImageUrl = image;
            }
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
            {
                //TODO:
                //errorMessage.Text = "Something went wrong. Please refresh the page and make sure you are logged in.";
                return;
            }
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
    }
}