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
    public class LoginStatusControlSteps
    {
        [Given(@"user is logged in as ""(.*)""")]
        public void GivenUserIsLoggedInAs(string username)
        {
            const string email = "test@pitchdea.com";
            const string password = "password123";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);

            auth.RegisterNewUser(username, email, password);

            var root = new Uri(WebBrowser.BaseUrl);
            var absoluteUrl = new Uri(root, "/loginPage.aspx");
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
            Assert.AreEqual(absoluteUrl, WebBrowser.Current.Url);

            IWebElement emailBox = WebBrowser.Current.FindElement(By.Id("MainContent_emailTextBox"));
            emailBox.SendKeys(email);

            IWebElement passwordBox = WebBrowser.Current.FindElement(By.Id("MainContent_passwordTextBox"));
            passwordBox.SendKeys(password);

            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_loginButton"));
            fieldElement.Click();
            Thread.Sleep(1000);
        }

        [Then(@"""(.*)"" link should be on the page")]
        public void ThenLinkShouldBeOnThePage(string linkText)
        {
            IWebElement linkElement = WebBrowser.Current.FindElement(By.LinkText(linkText));
            Assert.NotNull(linkElement);
        }

        [Then(@"""(.*)"" link should not be on the page")]
        public void ThenLinkShouldNotBeOnThePage(string linkText)
        {
            Assert.Throws<NoSuchElementException >(() => WebBrowser.Current.FindElement(By.LinkText(linkText)));
        }

        [When(@"user clicks ""(.*)"" link")]
        public void WhenUserClicksLink(string linkText)
        {
            var element = WebBrowser.Current.FindElement(By.LinkText(linkText));
            element.Click();
            Thread.Sleep(1000);
        }

        [Then(@"user is not logged in")]
        public void ThenUserIsNotLoggedIn()
        {
            Assert.Throws<NoSuchElementException>(() => WebBrowser.Current.FindElement(By.Id("loginStatusControl_activeUserLabel")));
        }
        
        [When(@"I click login button")]
        public void WhenIClickLoginButton()
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_loginButton"));
            element.Click();
            Thread.Sleep(1000);
        }
    }
}
