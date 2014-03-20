using System.Linq;
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
            Thread.Sleep(1000);
        }

        [Then(@"first comment is ""(.*)""")]
        public void ThenFirstCommentIs(string comment)
        {
            var elements = WebBrowser.Current.FindElements(By.Id("MainContent_comment1"));
            Assert.AreEqual(1, elements.Count);

            var commentDiv = elements.Single();
            var commentTextElement = commentDiv.FindElement(By.ClassName("commentText"));
            Assert.AreEqual(comment, commentTextElement.Text);
        }

        [Then(@"first comment was submitted by ""(.*)""")]
        public void ThenFirstCommentWasSubmittedBy(string submitter)
        {
            var elements = WebBrowser.Current.FindElements(By.Id("MainContent_comment1"));
            Assert.AreEqual(1, elements.Count);

            var commentDiv = elements.Single();
            var submitterElement = commentDiv.FindElement(By.ClassName("commentSubmitter"));
            Assert.AreEqual(submitter, submitterElement.Text);
        }

        [Then(@"first comment has posted time field")]
        public void ThenFirstCommentHasPostedTimeField()
        {
            var elements = WebBrowser.Current.FindElements(By.Id("MainContent_comment1"));
            Assert.AreEqual(1, elements.Count);

            var commentDiv = elements.Single();
            Assert.DoesNotThrow(() =>commentDiv.FindElement(By.ClassName("commentSubmitter")));
        }

        [Then(@"there are (.*) comments")]
        public void ThenThereAreComments(int commentCount)
        {
            var elements = WebBrowser.Current.FindElements(By.ClassName("commentBox"));
            Assert.AreEqual(commentCount, elements.Count);
        }
    }
}
