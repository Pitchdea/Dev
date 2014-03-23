using System;
using System.Linq;
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

            var absoluteUrl = WebBrowser.BaseUrl + "/viewIdeaPage.aspx?ID=" + hash;
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
            Assert.AreEqual(WebBrowser.BaseUrl + "/editIdeaPage.aspx",raw.First());
        }

        [Then(@"editable idea title is ""(.*)""")]
        public void ThenEditableIdeaTitleIs(string title)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"editable idea summary is ""(.*)""")]
        public void ThenEditableIdeaSummaryIs(string summary)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"editable idea description is ""(.*)""")]
        public void ThenEditableIdeaDescriptionIs(string description)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"editable idea question is ""(.*)""")]
        public void ThenEditableIdeaQuestionIs(string question)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit idea title to ""(.*)""")]
        public void WhenIEditIdeaTitleTo(string title)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit idea summary to ""(.*)""")]
        public void WhenIEditIdeaSummaryTo(string summary)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit idea description to ""(.*)""")]
        public void WhenIEditIdeaDescriptionTo(string description)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I edit idea question to ""(.*)""")]
        public void WhenIEditIdeaQuestionTo(string question)
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I press submit changes button")]
        public void WhenIPressSubmitChangesButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"edit idea button does not exist")]
        public void ThenEditIdeaButtonDoesNotExist()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I extend idea title with ""(.*)""")]
        public void WhenIExtendIdeaTitleWith(string title)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I extend idea summary with ""(.*)""")]
        public void WhenIExtendIdeaSummaryWith(string summary)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I extend idea description with ""(.*)""")]
        public void WhenIExtendIdeaDescriptionWith(string description)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I extend idea question with ""(.*)""")]
        public void WhenIExtendIdeaQuestionWith(string question)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
