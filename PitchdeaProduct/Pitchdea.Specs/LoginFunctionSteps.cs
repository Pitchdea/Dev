using System;
using NUnit.Framework;
using Pitchdea.Specs.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs
{
    [Binding]
    public class LoginFunctionSteps
    {
        [Given(@"page ""(.*)"" is open")]
        public void GivenPageIsOpen(string url)
        {
            var root = new Uri(WebBrowser.BaseUrl);
            var absoluteUrl = new Uri(root, url);
            WebBrowser.Current.GoTo(absoluteUrl);
            Assert.AreEqual(absoluteUrl, WebBrowser.Current.Url);
        }
        
        [Then(@"page title should be ""(.*)""")]
        public void ThenPageTitleShouldBe(string title)
        {
            Assert.AreEqual(title, WebBrowser.Current.Title);
        }
    }
}
