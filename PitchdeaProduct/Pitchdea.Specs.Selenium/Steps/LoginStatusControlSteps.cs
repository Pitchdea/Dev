using System;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class LoginStatusControlSteps
    {
        [Given(@"user is logged in as ""(.*)""")]
        public void GivenUserIsLoggedInAs(string username)
        {
            var authenticator = new Authenticator(SqlTestTool.TestConnectionString);
            throw new NotImplementedException();
        }
    }
}
