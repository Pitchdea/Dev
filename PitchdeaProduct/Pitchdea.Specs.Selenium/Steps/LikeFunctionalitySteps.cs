using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using OpenQA.Selenium;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
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

        [When(@"I click the dislike button")]
        public void WhenIClickTheDislikeButton()
        {
            var button = WebBrowser.Current.FindElement(By.Id("MainContent_noButton"));
            button.Click();
            Thread.Sleep(1000);
        }

        [Then(@"number of likes is ""(.*)""")]
        public void ThenNumberOfLikesIs(string like)
        {
            var likeElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaLikeLabel"));
            Assert.AreEqual(like, likeElement.Text); 
        }

        [Then(@"number of dislikes in database is ""(.*)""")]
        public void ThenNumberOfDislikesInDatabaseIs(string dislike)
        {
            var tool = new MySqlTool(SqlTestTool.TestConnectionString);
            var ideas = tool.FetchAllIdeas();
            Assert.AreEqual(int.Parse(dislike), ideas.Single().Dislikes); //TODO this works for this step but isn't truly deterministic
        }

        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            WebBrowser.Current.Navigate().Refresh();
        }
    }
}
