using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pitchdea.Core.Test.Utils;

namespace Pitchdea.Core.Test
{
    [TestFixture]
    public class SqlToolTest
    {
        private const string TestConnectionString = "SERVER=localhost; DATABASE=pitchdeatest; UID=test; PASSWORD=test;";
        private readonly MySqlTool _mySqlTool;
        private readonly SqlTestTool _sqlTestTool;

        public SqlToolTest()
        {
            _sqlTestTool = new SqlTestTool();
            _mySqlTool = new MySqlTool(TestConnectionString);
        }

        [Test]
        public void _01_InsertRowAndRemoveRow()
        {
            _sqlTestTool.CleanTestTable();

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

            _sqlTestTool.CleanTestTable();
        }
        
        [Test]
        public void _02_QueryEmptyTable()
        {
            _sqlTestTool.CleanTestTable();

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

            _sqlTestTool.CleanTestTable();
        }
    }
}
