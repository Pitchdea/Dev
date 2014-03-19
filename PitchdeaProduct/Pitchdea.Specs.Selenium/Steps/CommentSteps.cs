using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class CommentSteps
    {
        [When(@"I fill comment field with text ""(.*)""")]
        public void WhenIFillCommentFieldWithText(string comment)
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_commentTextBox"));
            element.SendKeys(comment);
        }

        [When(@"I click submit comment button")]
        public void WhenIClickSubmitCommentButton()
        {
            var element = WebBrowser.Current.FindElement(By.Id("MainContent_submitCommentButton"));
            element.Click();
        }

        [Then(@"first comment is ""(.*)""")]
        public void ThenFirstCommentIs(string comment)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"first comment was submitted by ""(.*)""")]
        public void ThenFirstCommentWasSubmittedBy(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"first comment has posted time field")]
        public void ThenFirstCommentHasPostedTimeField()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
