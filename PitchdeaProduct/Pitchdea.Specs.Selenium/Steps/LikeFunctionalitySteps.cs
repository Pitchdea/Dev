using System.Threading;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]

    public class LikeFunctionalitySteps
    {
        [When(@"I click the like button")]
        public void WhenIClickTheLikeButton()
        {
            var button = WebBrowser.Current.FindElement(By.Id("MainContent_yesButton"));
            button.Click();
            Thread.Sleep(1000);
        }

        [Then(@"number of likes is ""(.*)""")]
        public void ThenNumberOfLikesIs(string like)
        {
            var likeElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaLikeLabel"));
            Assert.AreEqual(like, likeElement.Text); 
        }

        [Given(@"number of likes is ""(.*)""")]
        public void GivenNumberOfLikesIs(string like)
        {
            var likeElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaLikeLabel"));
            Assert.AreEqual(like, likeElement.Text); 
        }

        [When(@"I click the dislike button")]
        public void WhenIClickTheDislikeButton()
        {
            var button = WebBrowser.Current.FindElement(By.Id("MainContent_noButton"));
            button.Click();
            Thread.Sleep(1000);
        }

        [Then(@"number of dislikes in database is ""(.*)""")]
        public void ThenNumberOfDislikesInDatabaseIs(string dislike)
        {
            var dislikeElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaLikeLabel"));
            Assert.AreEqual(dislike, dislikeElement.Text); 
        }

        [Given(@"number of dislikes in database is ""(.*)""")]
        public void GivenNumberOfDislikesInDatabaseIs(int dislike)
        {
            var dislikeElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaLikeLabel"));
            Assert.AreEqual(dislike, dislikeElement.Text); 
        }
        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            WebBrowser.Current.Navigate().Refresh();
            //WebBrowser.Current.FindElement(By.Id("MainContent_descriptionTextBox")).SendKeys(Keys.F5);

        }

    }
}
