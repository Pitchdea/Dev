using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"the user database is empty first")]
        public void GivenTheUserDatabaseIsEmptyFirst()
        {
            var sqlTool = new SqlTestTool();
            sqlTool.CleanUsers();
        }

        [Given(@"user ""(.*)"" with password ""(.*)"" exists in the database")]
        public void GivenUserWithPasswordExistsInTheDatabase(string email, string password)
        {
            var authenticator = new Authenticator(SqlTestTool.TestConnectionString);
            authenticator.RegisterNewUser(email, password);
        }

        [Given(@"page ""(.*)"" is open")]
        public void GivenPageIsOpen(string url)
        {
            var root = new Uri(WebBrowser.BaseUrl);
            var absoluteUrl = new Uri(root, url);
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
            Assert.AreEqual(absoluteUrl, WebBrowser.Current.Url);
        }
        
        [Given(@"""(.*)"" field value is ""(.*)""")]
        public void GivenFieldValueIs(string fieldId, string value)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id(fieldId));
            fieldElement.SendKeys(value);
        }

        [When(@"user clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string buttonId)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id(buttonId));
            fieldElement.Click();
            Thread.Sleep(500); //TODO: wait for the page to load, is there a "correct" way for doing this?
        }

        [Then(@"page ""(.*)"" is open")]
        public void ThenPageIsOpen(string url)
        {
            var root = new Uri(WebBrowser.BaseUrl);
            var absoluteUrl = new Uri(root, url);
            Assert.AreEqual(absoluteUrl, WebBrowser.Current.Url);
        }

        [Then(@"user is logged in as ""(.*)""")]
        public void ThenUserIsLoggedInAs(string userName)
        {
            IWebElement labelElement = WebBrowser.Current.FindElement(By.Id("MainContent_activeUserLabel"));
            Assert.AreEqual(userName, labelElement.Text);
        }

        [When(@"user hits enter key while ""(.*)"" is focused")]
        public void WhenUserHitsEnterKeyWhileIsFocused(string fieldId)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id(fieldId));
            fieldElement.SendKeys(Keys.Enter);
            Thread.Sleep(500); //TODO: wait for the page to load, is there a "correct" way for doing this?
        }

        [AfterScenario]
        public static void CloseDriver()
        {
            WebBrowser.Close();
        }
    }
}
