using System;
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
    public class ShowAllIdeasSteps
    {
        [Given(@"an idea exists with values: ""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void GivenAnIdeaExistsWithValues(string title, string summary, string description, string question)
        {
            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);
            
            try
            {
                auth.RegisterNewUser(username, email, password);
            }
            catch
            {
                //Suppress errors caused when the user is already registered by previous call
            }
            var userInfo = auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);

            var idea = new Idea(userInfo.UserID, title, summary, description, question);

            sqlTool.InsertIdea(idea);
        }
        
        [Given(@"an idea with image exists with values: ""(.*)"",""(.*)"",""(.*)"",""(.*)"",""(.*)""")]
        public void GivenAnIdeaWithImageExistsWithValues(string title, string imagePath, string summary, string description, string question)
        {

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);

            try
            {
                auth.RegisterNewUser(username, email, password);
            }
            catch
            {
                //Suppress errors caused when the user is already registered by previous call
            }
            var userInfo = auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);

            var idea = new Idea(userInfo.UserID, title, summary, description, question) { ImagePath = imagePath};

            sqlTool.InsertIdea(idea);
        }
        
        [Then(@"idea with ""(.*)"" should be on the page")]
        public void ThenIdeaWithShouldBeOnThePage(string title)
        {
            Assert.DoesNotThrow(() => WebBrowser.Current.FindElement(By.PartialLinkText(title)));
        }

        [When(@"I click idea ""(.*)""")]
        public void WhenIClickIdea(string title)
        {
            var link = WebBrowser.Current.FindElement(By.PartialLinkText(title));
            link.Click();
            Thread.Sleep(1000);
        }

    }
}
