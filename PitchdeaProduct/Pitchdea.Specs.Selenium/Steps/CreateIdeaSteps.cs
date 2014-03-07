using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class CreateIdeaSteps
    {
        [Given(@"I fill idea title ""(.*)""")]
        public void GivenIFillIdeaTitle(string content)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_titleTextBox"));
            titleElement.SendKeys(content);
        }

        [Given(@"I fill idea summary ""(.*)""")]
        public void GivenIFillIdeaSummary(string content)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryTextBox"));
            summaryElement.SendKeys(content);
        }

        [Given(@"I fill idea description ""(.*)""")]
        public void GivenIFillIdeaDescription(string content)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionTextBox"));
            descriptionElement.SendKeys(content);
        }

        [Given(@"I fill idea question ""(.*)""")]
        public void GivenIFillIdeaQuestion(string question)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_questionTextBox"));
            descriptionElement.SendKeys(question);
        }

        [When(@"I click create idea button")]
        public void WhenIClickCreateIdeaButton()
        {
            var button = WebBrowser.Current.FindElement(By.Id("MainContent_createIdeaButton"));
            button.Click();
            Thread.Sleep(1000);
        }

        [Then(@"idea title is ""(.*)""")]
        public void ThenIdeaTitleIs(string title)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_titleLabel"));
            Assert.AreEqual(title, titleElement.Text);
        }

        [Then(@"idea summary is ""(.*)""")]
        public void ThenIdeaSummaryIs(string summmary)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryLabel"));
            Assert.AreEqual(summmary, summaryElement.Text);
        }

        [Then(@"idea description is ""(.*)""")]
        public void ThenIdeaDescriptionIs(string description)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionLabel"));
            Assert.AreEqual(description, descriptionElement.Text);
        }

        [Then(@"idea owner is ""(.*)""")]
        public void ThenIdeaOwnerIs(string owner)
        {
            var ownerElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaOwner"));
            Assert.AreEqual(owner, ownerElement.Text);
        }

        [Given(@"I fill idea summary with lines")]
        public void GivenIFillIdeaSummaryWithLines(string multilineText)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryTextBox"));
            summaryElement.SendKeys(multilineText);
        }

        [Given(@"I fill idea description with lines")]
        public void GivenIFillIdeaDescriptionWithLines(string multilineText)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionTextBox"));
            summaryElement.SendKeys(multilineText);
        }

        [Then(@"idea summary is multiline:")]
        public void ThenIdeaSummaryIsMultiline(string multilineText)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryLabel"));
            Assert.AreEqual(multilineText, summaryElement.Text);
        }

        [Then(@"idea description is multiline:")]
        public void ThenIdeaDescriptionIsMultiline(string multilineText)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionLabel"));
            Assert.AreEqual(multilineText, descriptionElement.Text);
        }

        [Then(@"idea question is ""(.*)""")]
        public void ThenIdeaQuestionIs(string question)
        {
            var questionElement = WebBrowser.Current.FindElement(By.Id("MainContent_questionLabel"));
            Assert.AreEqual(question, questionElement.Text);
        }
        
        [When(@"I choose to upload a picture ""(.*)""")]
        public void WhenIChooseToUploadAPicture(string picture)
        {
            //sets the value of the ImgUpload field to the value of savePath
            String script = "document.getElementById('MainContent_ImgUpload').value='" + picture + "';";
            //var foo = ((IJavaScriptExecutor)WebBrowser.Current).ExecuteScript(script);
            //Console.WriteLine(foo);
            var uploadElement = WebBrowser.Current.FindElement(By.Id("MainContent_ImgUpload"));
            uploadElement.SendKeys(picture);
        }

        [Then(@"the image path is ""(.*)""")]
        public void ThenTheImagePathIs(string path)
        {
            var uploadElement = WebBrowser.Current.FindElement(By.Id("MainContent_ImgUpload"));
            Assert.AreEqual(path, uploadElement.Text); //todo: fix reference
        }

        [When(@"I click upload image button")]
        public void WhenIClickUploadImageButton()
        {
            IWebElement uploadButton= WebBrowser.Current.FindElement(By.Id("MainContent_uploadImageButton"));
            uploadButton.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I get an Ok message ""(.*)""")]
        public void ThenIGetAnOkMessage(string message)
        {
            var uploadStatusElement = WebBrowser.Current.FindElement(By.Id("MainContent_uploadStatusLabel"));
            Assert.AreEqual(message, uploadStatusElement.Text); //todo: fix reference
        }

        [Then(@"shown image is not ""(.*)""")]
        public void ThenShownImageIsNot(string ideaSrc)
        {
            var img = WebBrowser.Current.FindElement(By.Id("MainContent_ideaImage"));
            var src = img.GetAttribute("src");
            Assert.AreNotEqual(ideaSrc, src); 
        }

        [Given(@"I fill idea title with ""(.*)"" characters")]
        public void GivenIFillIdeaTitleWithCharacters(int count)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_titleTextBox"));
            var content = GenerateRandomContent(count);
            titleElement.SendKeys(content);
        }

        [Given(@"I fill idea summary with ""(.*)"" characters")]
        public void GivenIFillIdeaSummaryWithCharacters(int count)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryTextBox"));
            var content = GenerateRandomContent(count);
            titleElement.SendKeys(content);
        }

        [Given(@"I fill idea description with ""(.*)"" characters")]
        public void GivenIFillIdeaDescriptionWithCharacters(int count)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionTextBox"));
            var content = GenerateRandomContent(count);
            titleElement.SendKeys(content);
        }

        [Given(@"I fill idea question with ""(.*)"" characters")]
        public void GivenIFillIdeaQuestionWithCharacters(int count)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_questionTextBox"));
            var content = GenerateRandomContent(count);
            titleElement.SendKeys(content);
        }
        
        private string GenerateRandomContent(int count)
        {
            var result = "";
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                result += random.Next(0, 10);
            }
            return result;
        }

        [Then(@"image preview should be shown")]
        public void ThenImagePreviewShouldBeShown()
        {
            Assert.DoesNotThrow((() => WebBrowser.Current.FindElement(By.Id("MainContent_previewImage"))));
        }

        [Then(@"image preview should not be shown")]
        public void ThenImagePreviewShouldNotBeShown()
        {
            Assert.Throws<NoSuchElementException>(() =>WebBrowser.Current.FindElement(By.Id("MainContent_previewImage")));
        }

    }
}
