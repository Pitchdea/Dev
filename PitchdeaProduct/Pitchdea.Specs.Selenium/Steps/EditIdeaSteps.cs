using System;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Core;
using Pitchdea.Core.Model;
using Pitchdea.Core.Test.Utils;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class EditIdeaSteps
    {
        [Given(@"user is logged in \(with password\) as ""(.*)"" with password ""(.*)""")]
        public void GivenUserIsLoggedInWithPasswordAsWithPassword(string username, string password)
        {
            const string email = "test@pitchdea.com";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);

            auth.RegisterNewUser(username, email, password);

            var root = new Uri(WebBrowser.BaseUrl);
            var absoluteUrl = new Uri(root, "/loginPage.aspx");
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
            Assert.AreEqual(absoluteUrl, WebBrowser.Current.Url);

            IWebElement emailBox = WebBrowser.Current.FindElement(By.Id("MainContent_emailTextBox"));
            emailBox.SendKeys(username);

            IWebElement passwordBox = WebBrowser.Current.FindElement(By.Id("MainContent_passwordTextBox"));
            passwordBox.SendKeys(password);

            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_loginButton"));
            fieldElement.Click();
            Thread.Sleep(1000);
        }

        [Given(@"an idea submitted by ""(.*)"" with password ""(.*)""  exists with values: ""(.*)"",""(.*)"",""(.*)"",""(.*)"" and the page for that idea is open")]
        public void GivenAnIdeaSubmittedByWithPasswordExistsWithValuesAndThePageForThatIdeaIsOpen(string username, string password, string title, string summary, string description, string question)
        {
            var auth = new Authenticator(SqlTestTool.TestConnectionString);
            var userInfo = auth.Authenticate(username, password);

            Assert.NotNull(userInfo);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);

            var idea = new Idea(userInfo.UserId, title, summary, description, question);

            var hash = sqlTool.InsertIdea(idea).Hash;

            var absoluteUrl = WebBrowser.BaseUrl + "viewIdeaPage.aspx?ID=" + hash;
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
        }

        [Given(@"an idea submitted by ""(.*)"" with password ""(.*)"" with image exists with values: ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)"" and the page for that idea is open\.")]
        public void GivenAnIdeaSubmittedByWithPasswordWithImageExistsWithValuesAndThePageForThatIdeaIsOpen_(string username, string password, string title, string image, string summary, string description, string question)
        {
            var auth = new Authenticator(SqlTestTool.TestConnectionString);
            var userInfo = auth.Authenticate(username, password);

            Assert.NotNull(userInfo);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = image};

            var hash = sqlTool.InsertIdea(idea).Hash;

            var absoluteUrl = WebBrowser.BaseUrl + "viewIdeaPage.aspx?ID=" + hash;
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
        }


        [When(@"I press edit idea button")]
        public void WhenIPressEditIdeaButton()
        {
            var editButton = WebBrowser.Current.FindElement(By.Id("MainContent_editIdeaLink"));
            editButton.Click();
        }

        [Then(@"edit page for ""(.*)"" is open")]
        public void ThenEditPageForIsOpen(string title)
        {
            const string pitchdeaPart = " | Pitchdea";
            Assert.AreEqual(title + pitchdeaPart, WebBrowser.Current.Title);
            var raw = WebBrowser.Current.Url.Split('?');
            Assert.AreEqual(WebBrowser.BaseUrl + "editIdeaPage.aspx",raw.First());
        }

        [Then(@"editable idea title is ""(.*)""")]
        public void ThenEditableIdeaTitleIs(string title)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaTitleTextBox"));
            Assert.AreEqual(title, element.GetAttribute("value"));
        }

        [Then(@"editable idea summary is ""(.*)""")]
        public void ThenEditableIdeaSummaryIs(string summary)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaSummaryTextBox"));
            Assert.AreEqual(summary, element.GetAttribute("value"));
        }

        [Then(@"editable idea description is ""(.*)""")]
        public void ThenEditableIdeaDescriptionIs(string description)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaDescriptionTextBox"));
            Assert.AreEqual(description, element.GetAttribute("value"));
        }

        [Then(@"editable idea question is ""(.*)""")]
        public void ThenEditableIdeaQuestionIs(string question)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaQuestionTextBox"));
            Assert.AreEqual(question, element.GetAttribute("value"));
        }

        [When(@"I edit idea title to ""(.*)""")]
        public void WhenIEditIdeaTitleTo(string title)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaTitleTextBox"));
            element.Clear();
            element.SendKeys(title);
        }

        [When(@"I edit idea summary to ""(.*)""")]
        public void WhenIEditIdeaSummaryTo(string summary)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaSummaryTextBox"));
            element.Clear();
            element.SendKeys(summary);
        }

        [When(@"I edit idea description to ""(.*)""")]
        public void WhenIEditIdeaDescriptionTo(string description)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaDescriptionTextBox"));
            element.Clear();
            element.SendKeys(description);
        }

        [When(@"I edit idea question to ""(.*)""")]
        public void WhenIEditIdeaQuestionTo(string question)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaQuestionTextBox"));
            element.Clear();
            element.SendKeys(question);
        }

        [When(@"I press submit changes button")]
        public void WhenIPressSubmitChangesButton()
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_submitChangesButton"));
            element.Click();
        }

        [Then(@"edit idea button does not exist")]
        public void ThenEditIdeaButtonDoesNotExist()
        {
            Assert.Throws<NoSuchElementException>(() => WebBrowser.Current.FindElement(By.Id("MainContent_editIdeaLink")));
        }

        [When(@"I extend idea title with ""(.*)""")]
        public void WhenIExtendIdeaTitleWith(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaTitleTextBox"));
            element.SendKeys(multilineText);
        }

        [When(@"I extend idea summary with")]
        public void WhenIExtendIdeaSummaryWith(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaSummaryTextBox"));
            element.SendKeys(multilineText);
        }

        [When(@"I extend idea description with")]
        public void WhenIExtendIdeaDescriptionWith(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaDescriptionTextBox"));
            element.SendKeys(multilineText);
        }

        [When(@"I extend idea question with")]
        public void WhenIExtendIdeaQuestionWith(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_ideaQuestionTextBox"));
            element.SendKeys(multilineText);
        }

        [Then(@"idea summary is")]
        public void ThenIdeaSummaryIs(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_summaryLabel"));
            Assert.AreEqual(multilineText, element.Text);
        }

        [Then(@"idea description is")]
        public void ThenIdeaDescriptionIs(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionLabel"));
            Assert.AreEqual(multilineText, element.Text);
        }

        [Then(@"idea question is")]
        public void ThenIdeaQuestionIs(string multilineText)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_questionLabel"));
            Assert.AreEqual(multilineText, element.Text);
        }

        [When(@"I press use default picture button")]
        public void WhenIPressUseDefaultPictureButton()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
