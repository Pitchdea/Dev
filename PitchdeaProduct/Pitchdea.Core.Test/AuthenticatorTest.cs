using System;
using System.Globalization;
using NUnit.Framework;
using Pitchdea.Core.Test.Utils;

namespace Pitchdea.Core.Test
{
    [TestFixture]
    public class AuthenticatorTest
    {
        private SqlTestTool _sqlTestTool;
        private Authenticator _auth;

        [SetUp]
        public void SetUp()
        {
            _sqlTestTool = new SqlTestTool();
            _auth = new Authenticator(SqlTestTool.TestConnectionString);
        }

        [Test]
        public void _01_SanityCheck()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string pw = "123123";
            _auth.RegisterNewUser("test","testi@testi.com", pw);
        }

        [Test]
        public void _02_IterateRandomPasswords()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);
                    _auth.RegisterNewUser("test"+i,"testi"+i+"@testi.com", pw);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Iteration: " + i);
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void _03_RegisterAndAuthenticate_WithUserName()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string email = "testi@testi.com";
            const string username = "test";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            _auth.RegisterNewUser(username, email, pw);
            var result = _auth.Authenticate(username, pw);

            Assert.NotNull(result);
            Assert.AreEqual(username, result.Username);
        }

        [Test]
        public void _04_RegisterAndAuthenticate_WithEmail()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string email = "testi@testi.com";
            const string username = "test";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            _auth.RegisterNewUser(username, email, pw);
            var result = _auth.Authenticate(email, pw);

            Assert.NotNull(result);
            Assert.AreEqual(username, result.Username);
        }

        [Test]
        public void _05_CheckIfUsernameExists()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string email = "testi@testi.com";
            const string username = "test";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            var result = _auth.RegisterNewUser(username, email, pw);

            Assert.NotNull(result);
            Assert.AreEqual(username, result.Username);

            var exists = _auth.CheckIfUsernameExists(username);

            Assert.True(exists);
        }

        [Test]
        public void _05_CheckIfEmailExists()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string email = "testi@testi.com";
            const string username = "test";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            var result = _auth.RegisterNewUser(username, email, pw);

            Assert.NotNull(result);
            Assert.AreEqual(username, result.Username);

            var exists = _auth.CheckIfEmailExists(email);

            Assert.True(exists);
        }
    }
}
