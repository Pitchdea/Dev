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
            _sqlTestTool.CleanTable("user");

            var pw = "123123";
            _auth.RegisterNewUser("test","testi@testi.com", pw);

            _sqlTestTool.CleanTable("user");
        }

        [Test]
        public void _02_IterateRandomPasswords()
        {
            _sqlTestTool.CleanTable("user");

            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);
                    _auth.RegisterNewUser("test","testi@testi.com", pw);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Iteration: " + i);
                    Assert.Fail();
                }
            }

            _sqlTestTool.CleanTable("user");
        }

        [Test]
        public void _03_RegisterAndAuthenticate()
        {
            _sqlTestTool.CleanTable("user");

            const string email = "testi@testi.com";
            const string username = "test";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            _auth.RegisterNewUser(username, email, pw);
            var result = _auth.Authenticate(email, pw);

            Assert.AreNotEqual(-1, result);

            _sqlTestTool.CleanTable("user");
        }
    }
}
