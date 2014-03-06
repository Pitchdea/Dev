using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"the user database is empty first")]
        public void GivenTheUserDatabaseIsEmptyFirst()
        {
            var sqlTool = new SqlTestTool();
            sqlTool.CleanTable("user");
        }

        [Given(@"user ""(.*)"" with email ""(.*)"" with password ""(.*)"" exists in the database")]
        public void GivenUserWithPasswordExistsInTheDatabase(string username, string email, string password)
        {
            var authenticator = new Authenticator(SqlTestTool.TestConnectionString);
            authenticator.RegisterNewUser(username, email, password);
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
            Thread.Sleep(1000);
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
            IWebElement labelElement = WebBrowser.Current.FindElement(By.Id("loginStatusControl_activeUserLabel"));
            Assert.AreEqual(userName, labelElement.Text);
        }

        [When(@"user hits enter key while ""(.*)"" is focused")]
        public void WhenUserHitsEnterKeyWhileIsFocused(string fieldId)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id(fieldId));
            fieldElement.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        [Then(@"""(.*)"" field value is ""(.*)""")]
        public void ThenFieldValueIs(string fieldId, string value)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id(fieldId));
            Assert.AreEqual(value, fieldElement.Text);
        }

        [AfterScenario]
        public static void CloseDriver()
        {
            WebBrowser.Close();
        }
    }
}
