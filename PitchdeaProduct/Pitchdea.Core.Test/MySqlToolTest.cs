using MySql.Data.MySqlClient;
using NUnit.Framework;
using Pitchdea.Core.Test.Utils;
using System.Globalization;

namespace Pitchdea.Core.Test
{
    [TestFixture]
    public class MySqlToolTest
    {
        private readonly MySqlTool _mySqlTool;
        private readonly SqlTestTool _sqlTestTool;
        private readonly Authenticator _auth;

        public MySqlToolTest()
        {
            _sqlTestTool = new SqlTestTool();
            _mySqlTool = new MySqlTool(SqlTestTool.TestConnectionString);
            _auth = new Authenticator(SqlTestTool.TestConnectionString);
        }

        [Test]
        public void _01_InsertRowAndRemoveRow()
        {
            _sqlTestTool.CleanTable("test");

            const int integerNumber = 2;
            const string textString = "asd";
            const float floatNumber = 12.3f;
            const double doubleNumber = 23.5d;

            var query =
                string.Format("INSERT INTO test (integerNumber, textString, floatNumber, doubleNumber) VALUES('{0}','{1}','{2}','{3}');",
                    integerNumber, textString, floatNumber.ToString(CultureInfo.InvariantCulture), doubleNumber.ToString(CultureInfo.InvariantCulture));

            var result = _mySqlTool.ExecuteNonQuery(query);

            Assert.AreEqual(1, result);

            var query2 =
                string.Format("SELECT integerNumber, textString, floatNumber, doubleNumber FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result2 = _mySqlTool.ReadDataSet(query2);

            Assert.AreEqual(1, result2.GetLength(0));
            Assert.AreEqual(integerNumber, result2[0,0]);
            Assert.AreEqual(textString, result2[0, 1]);
            Assert.AreEqual(floatNumber, result2[0, 2]);
            Assert.AreEqual(doubleNumber, result2[0, 3]);

            var query3 =
                string.Format("SELECT integerNumber, textString, floatNumber, doubleNumber FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result3 = _mySqlTool.ReadSingleValue(query3);

            Assert.AreEqual(2, (int)result3);

            var query4 =
                string.Format(
                    "DELETE FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result4 = _mySqlTool.ExecuteNonQuery(query4);

            Assert.AreEqual(1, result4);

            _sqlTestTool.CleanTable("test");
        }
        
        [Test]
        public void _02_QueryEmptyTable()
        {
            _sqlTestTool.CleanTable("test");

            const int integerNumber = 2;
            const string textString = "asd";

            var query2 =
                string.Format("SELECT integerNumber, textString, floatNumber, doubleNumber FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result2 = _mySqlTool.ReadDataSet(query2);

            Assert.AreEqual(0, result2.GetLength(0));

            var query3 =
                string.Format("SELECT integerNumber, textString, floatNumber, doubleNumber FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result3 = _mySqlTool.ReadSingleValue(query3);

            Assert.AreEqual(null, result3);

            var query4 =
                string.Format(
                    "DELETE FROM test WHERE integerNumber='{0}' AND textString='{1}';",
                    integerNumber, textString);

            var result4 = _mySqlTool.ExecuteNonQuery(query4);

            Assert.AreEqual(0, result4);

            _sqlTestTool.CleanTable("test");
        }

        [Test]
        public void _03_InsertIdea()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";

            InsertIdea(title, summary, description);

            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");
        }
        
        [Test]
        public void _04_InsertIdea_SpecialCharacters()
        {
            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");

            const string title = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\nn \t asd";
            const string summary = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\nn \t asd";
            const string description = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\n \t asd";

            InsertIdea( title, summary, description);

            _sqlTestTool.CleanTable("idea");
            _sqlTestTool.CleanTable("user");
        }

        private void InsertIdea(string title, string summary, string description)
        {
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(email, password);
            var userId = _auth.Authenticate(email, password);

            Assert.AreNotEqual(-1, userId);

            var hash = _mySqlTool.InsertIdea(userId, title, summary, description);

            Assert.False(string.IsNullOrEmpty(hash));

            var connection = new MySqlConnection(SqlTestTool.TestConnectionString);
            connection.Open();
            var cmd = new MySqlCommand(
                string.Format("SELECT hash, title, summary, description, userID FROM idea WHERE hash='{0}'", hash)
                , connection);

            cmd.Prepare();
            var reader = cmd.ExecuteReader();

            var result = new object[5];
            var canRead = reader.Read();

            try
            {
                result[0] = reader[0];
                result[1] = reader[1];
                result[2] = reader[2];
                result[3] = reader[3];
                result[4] = reader[4];
            }
            finally
            {
                connection.Close();
            }

            Assert.True(canRead);

            Assert.AreEqual(title, result[1]);
            Assert.AreEqual(summary, result[2]);
            Assert.AreEqual(description, result[3]);
            Assert.AreEqual(userId, result[4]);
        }
    }
}
