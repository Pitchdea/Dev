using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pitchdea.Core;
using Pitchdea.Core.Model;

namespace Pitchdea
{
    public partial class CreateIdeaPage : Page
    {
        private readonly ISqlTool _sqlTool = SqlToolFactory.CreateNew();

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

            var idea = new Idea((int)ownerId, title, summary, description, question);

            var insertedIdea = _sqlTool.InsertIdea(idea);

            Response.Redirect("viewIdeaPage.aspx?ID=" + insertedIdea.Hash);
        }

        protected void uploadImageButton_OnClick(object sender, EventArgs e)
        {
            // server location where the images are stored.
            string savePath = @"\images\ideapics\";

            // Verify that the ImgUpload controller has the file.
            if (!ImgUpload.HasFile)
            {
                // Notify the user their file was not uploaded.
                uploadStatusLabel.Text = "Oops! You forgot to specify an image to upload.";
                return;
            }

            // Allow only smaller than 100kB files.
            if (ImgUpload.PostedFile.ContentLength >= 102400)
            {
                // Notify the user their file was too big.
                uploadStatusLabel.Text = "Oops! Your image was bigger than the maximum 100kB.";
                return;
            }

            // Allow only .jpg files to be uploaded. TODO: This is still not safe, attacker could circumwent by renaming their malicious file.
            if (Path.GetExtension(ImgUpload.FileName) != ".jpg")
            {
                uploadStatusLabel.Text = "Oops! Your file was not a .jpg image.";
                return;
            }

            // Append the name of the uploaded file to the path.
            savePath += Server.HtmlEncode(ImgUpload.FileName);
            //TODO: Resize the file, 300px*300px perhaps?
            // Saves the image to the specified path. If a file with the same name already exists it will be overwritten.  
            ImgUpload.SaveAs(savePath);

            // Notify the user their file was uploaded successfully.
            uploadStatusLabel.Text = "Your image was uploaded successfully.";
        }
    }
}