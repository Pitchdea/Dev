using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium
{
    [Binding]
    public class LoginFunctionSteps
    {
        public const string BaseUrl = "http://localhost:28231/";

        [Given(@"page ""(.*)"" is open")]
        public void GivenPageIsOpen(string url)
        {
            IWebDriver driver = new InternetExplorerDriver(@"..\..\Tools\IEDriver");
            var root = new Uri(BaseUrl);
            var absoluteUrl = new Uri(root, url);
            driver.Navigate().GoToUrl(absoluteUrl);
            Assert.AreEqual(absoluteUrl, driver.Url);
        }
        
        [Then(@"page title should be ""(.*)""")]
        public void ThenPageTitleShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
