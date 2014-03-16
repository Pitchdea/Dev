using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium
{
    [Binding]
    public class CommentSteps
    {
        [Given(@"comment field is visible")]
        public void GivenCommentFieldIsVisible()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"page title is ""(.*)"" followed by ""(.*)""")]
        public void ThenPageTitleIsFollowedBy(string title, string pitchdeaPart)
        {
            Assert.AreEqual(title + pitchdeaPart, WebBrowser.Current.Title);
        }

        [Given(@"submit comment field is focused")]
        public void GivenSubmitCommentFieldIsFocused()
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_commentTextBox"));
        }

        [When(@"I fill comment field with text ""(.*)""")]
        public void WhenIFillCommentFieldWithText(string comment)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_commentTextBox"));
            fieldElement.SendKeys(comment);
        }

        [When(@"I click submit comment button")]
        public void WhenIClickSubmitCommentButton()
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_submitCommentButton"));
            fieldElement.Click();
            Thread.Sleep(1000);
        }

        [Then(@"a comment field value is ""(.*)""")]
        public void ThenACommentFieldValueIs(string value)
        {
            IWebElement fieldElement = WebBrowser.Current.FindElement(By.Id("MainContent_commentTextBox"));
            Assert.AreEqual(value, fieldElement.Text);
        }


    }
}
