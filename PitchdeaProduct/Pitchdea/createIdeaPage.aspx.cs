﻿using System;
using System.IO;
using System.Web.UI;
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
                return (string)this.ViewState["UploadedImage"];
            }
            set { this.ViewState["UploadedImage"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createIdeaButton_OnClick(object sender, EventArgs e)
        {
            var title = titleTextBox.Text;
            var summary = summaryTextBox.Text;
            var description = descriptionTextBox.Text;
            var question = questionTextBox.Text;
            var ownerId = Session["userId"];

            if (ownerId == null)
                throw new Exception();

            var idea = new Idea((int)ownerId, title, summary, description, question){ImagePath = UploadedImage};

            var insertedIdea = _sqlTool.InsertIdea(idea);

            Response.Redirect("viewIdeaPage.aspx?ID=" + insertedIdea.Hash);
        }

        protected void uploadImageButton_OnClick(object sender, EventArgs e)
        {
                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                var savePath = config.AppSettings.Settings["savePath"].Value;

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
            string imgLocation = Server.MapPath(savePath + fileName);
            // Renames and saves the image to the specified path. If a file with the same name already exists it will be overwritten.
            this.ImgUpload.SaveAs(imgLocation);
            
            // Notify the user their file was uploaded successfully.
            UploadedImage = fileName;
            uploadStatusLabel.Text = "Your image was uploaded successfully.";
        }
    }
}
