using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class CreateIdeaSteps
    {
        [Given(@"I fill idea title ""(.*)""")]
        public void GivenIFillIdeaTitle(string content)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_titleTextBox"));
            titleElement.SendKeys(content);
        }

        [Given(@"I fill idea summary ""(.*)""")]
        public void GivenIFillIdeaSummary(string content)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summaryTextBox"));
            summaryElement.SendKeys(content);
        }

        [Given(@"I fill idea description ""(.*)""")]
        public void GivenIFillIdeaDescription(string content)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionTextBox"));
            descriptionElement.SendKeys(content);
        }

        [When(@"user clicks create idea button")]
        public void WhenUserClicksCreateIdeaButton()
        {
            var button = WebBrowser.Current.FindElement(By.Id("MainContent_createIdeaButton"));
            button.Click();
            Thread.Sleep(1000);
        }

        [Then(@"idea title is ""(.*)""")]
        public void ThenIdeaTitleIs(string title)
        {
            var titleElement = WebBrowser.Current.FindElement(By.Id("MainContent_titleLabel"));
            Assert.AreEqual(title, titleElement.Text);
        }

        [Then(@"idea summary is ""(.*)""")]
        public void ThenIdeaSummaryIs(string summmary)
        {
            var summaryElement = WebBrowser.Current.FindElement(By.Id("MainContent_summmaryLabel"));
            Assert.AreEqual(summmary, summaryElement.Text);
        }

        [Then(@"idea description is ""(.*)""")]
        public void ThenIdeaDescriptionIs(string description)
        {
            var descriptionElement = WebBrowser.Current.FindElement(By.Id("MainContent_descriptionLabel"));
            Assert.AreEqual(description, descriptionElement.Text);
        }

        [Then(@"idea owner is ""(.*)""")]
        public void ThenIdeaOwnerIs(string owner)
        {
            var ownerElement = WebBrowser.Current.FindElement(By.Id("MainContent_ideaOwner"));
            Assert.AreEqual(owner, ownerElement.Text);
        }
    }
}
