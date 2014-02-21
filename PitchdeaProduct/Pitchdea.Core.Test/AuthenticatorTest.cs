using System;
using System.Globalization;
using NUnit.Framework;
using Pitchdea.Core.Test.Utils;

namespace Pitchdea.Core.Test
{
    [TestFixture]
    public class AuthenticatorTest
    {
        private SqlTestTool _sqlTool;
        private Authenticator _auth;

        [SetUp]
        public void SetUp()
        {
            _sqlTool = new SqlTestTool();
            _auth = new Authenticator(SqlTestTool.TestConnectionString);
        }

        [Test]
        public void _01_SanityCheck()
        {
            _sqlTool.CleanUsers();

            var pw = "123123";
            _auth.RegisterNewUser("testi@testi.com", pw);

            _sqlTool.CleanUsers();
        }

        [Test]
        public void _02_IterateRandomPasswords()
        {
            _sqlTool.CleanUsers();

            var random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);
                    _auth.RegisterNewUser("testi@testi.com", pw);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Iteration: " + i);
                    Assert.Fail();
                }
            }

            _sqlTool.CleanUsers();
        }

        [Test]
        public void _03_RegisterAndAuthenticate()
        {
            _sqlTool.CleanUsers();

            const string email = "testi@testi.com";

            var random = new Random();
            var pw = random.Next(0, 100000000).ToString(CultureInfo.InvariantCulture);

            _auth.RegisterNewUser(email, pw);
            var result = _auth.Authenticate(email, pw);

            Assert.AreNotEqual(-1, result);

            _sqlTool.CleanUsers();
        }
    }
}
