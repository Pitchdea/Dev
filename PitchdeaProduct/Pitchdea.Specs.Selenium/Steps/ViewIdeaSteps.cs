using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pitchdea.Core;
using Pitchdea.Core.Model;
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
            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            var auth = new Authenticator(SqlTestTool.TestConnectionString);

            auth.RegisterNewUser(username, email, password);
            var userInfo = auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            ISqlTool sqlTool = new MySqlTool(SqlTestTool.TestConnectionString);

            var idea = new Idea(userInfo.UserID, title, summary, description);

            var hash = sqlTool.InsertIdea(idea).Hash;

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
