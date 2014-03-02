using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class RegisterSteps
    {
        [When(@"I fill email field with ""(.*)""")]
        public void WhenIFillEmailFieldWith(string email)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_emailTextBox"));
            fieldElement.SendKeys(email);
        }
        [When(@"I fill the username field with ""(.*)""")]
        public void WhenIFillTheUsernameFieldWith(string username)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_usernameTextBox"));
            fieldElement.SendKeys(username);
        }
        [When(@"I fill the password field with ""(.*)""")]
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

    }
}
