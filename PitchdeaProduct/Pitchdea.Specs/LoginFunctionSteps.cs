using System;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs
{
    [Binding]
    public class LoginFunctionSteps
    {
        [When(@"page is loaded")]
        public void WhenPageIsLoaded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"page title should be ""(.*)""")]
        public void ThenPageTitleShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
