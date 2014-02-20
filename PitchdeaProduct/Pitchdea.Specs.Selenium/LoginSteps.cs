using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"user ""(.*)"" with password ""(.*)"" exists in the database")]
        public void GivenUserWithPasswordExistsInTheDatabase(string email, string password)
        {
            var sqlTool = new SqlTestTool();
            sqlTool.CleanUsers();

            var authenticator = new Authenticator(SqlTestTool.ConnectionString);
            authenticator.RegisterNewUser(email, password);
        }
    }
}
