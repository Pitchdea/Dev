using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pitchdea.Core;
using Pitchdea.Core.Test.Utils;
using Pitchdea.Specs.Selenium.Utils;
using TechTalk.SpecFlow;

namespace Pitchdea.Specs.Selenium.Steps
{
    [Binding]
    public class ViewIdeaSteps
    {
        [Given(@"""(.*)"" table is empty at first")]
        public void GivenTableIsEmptyAtFirst(string tableName)
        {
            var sqlTool = new SqlTestTool();
            sqlTool.CleanTable(tableName);
        }


        [Given(@"an idea exists with values: ""(.*)"",""(.*)"",""(.*)"" and the page for that idea is open\.")]
        public void GivenAnIdeaExistsWithValuesAndThePageForThatIdeaIsOpen_(string title, string summary, string description)
        {
            const string email = "test@pitchdea.com";
            const string password = "password123";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);

            auth.RegisterNewUser(email, password);
            var userId = auth.Authenticate(email, password);

            Assert.AreNotEqual(-1, userId);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);
            var hash = sqlTool.InsertIdea(userId, title, summary, description);

            var absoluteUrl = WebBrowser.BaseUrl + "/viewIdeaPage.aspx?ID=" + hash;
            WebBrowser.Current.Navigate().GoToUrl(absoluteUrl);
        }

        [Then(@"page title is ""(.*)"" followed by ""(.*)""")]
        public void ThenPageTitleIsFollowedBy(string title, string pitchdeaPart)
        {
            Assert.AreEqual(title+pitchdeaPart, WebBrowser.Current.Title);
        }

    }
}
