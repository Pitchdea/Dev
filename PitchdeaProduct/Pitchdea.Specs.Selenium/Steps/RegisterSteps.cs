using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using NUnit.Framework;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class RegisterSteps
    {
        [Given(@"user with email ""(.*)"" exists in the database")]
        public void GivenUserWithEmailExistsInTheDatabase(string email)
        {
            IAuthenticator authenticator = new Authenticator(SqlTestTool.TestConnectionString);
            authenticator.RegisterNewUser("mikko", email, "passu");
        }

        [Given(@"user with username ""(.*)"" is exists in the database")]
        public void GivenUserWithUsernameIsExistsInTheDatabase(string username)
        {
            IAuthenticator authenticator = new Authenticator(SqlTestTool.TestConnectionString);
            authenticator.RegisterNewUser(username, "test@pitchdea.com", "passu");
        }

        [When(@"I fill email field with ""(.*)""")]
        public void WhenIFillEmailFieldWith(string email)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_emailTextBox"));
            fieldElement.SendKeys(email);
        }

        [When(@"I fill username field with ""(.*)""")]
        public void WhenIFillTheUsernameFieldWith(string username)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_usernameTextBox"));
            fieldElement.SendKeys(username);
        }

        [When(@"I fill password field with ""(.*)""")]
        public void WhenIFillThePasswordFieldWith(string password)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_passwordTextBox"));
            fieldElement.SendKeys(password);
        }

        [When(@"I fill password confirmation field with ""(.*)""")]
        public void WhenIFillPasswordConfirmationFieldWith(string passwordconf)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_passwordConfirmationTextBox"));
            fieldElement.SendKeys(passwordconf);
        }

        [When(@"I click register button")]
        public void WhenIClickRegisterButton()
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_registerButton"));
            fieldElement.Click();
            Thread.Sleep(1000);
        }

        [When(@"I hit enter key while password confirmation field is focused")]
        public void WhenIHitEnterKeyWhilePasswordConfirmationFieldIsFocused()
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_passwordConfirmationTextBox"));
            fieldElement.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

        }

        [Then(@"I am logged in as ""(.*)""")]
        public void ThenIAmLoggedInAs(string userName)
        {
            IWebElement labelElement = WebBrowser.Current.FindElement(By.Id("HeaderContent_loginStatusControl_activeUserLabel"));
            Assert.AreEqual(userName, labelElement.Text);
        }

        [Then(@"I see ""(.*)"" error message")]
        public void ThenISeeErrorMessage(string value)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_errorMessage"));
            Assert.AreEqual(value, fieldElement.Text);
        }


    }
}
