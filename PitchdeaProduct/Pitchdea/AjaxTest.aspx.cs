using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Pitchdea.Core;

namespace Pitchdea
{
    public partial class AjaxTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var number = GetNumber();
            Label1.Text = number.ToString();
            ajaxLabel1.Text = number.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var number = IncreaseLikes();
            ajaxLabel1.Text = number.ToString();
        }

        private int IncreaseLikes()
        {
            var connection = new MySqlConnection(SqlToolFactory.ConnectionString);
            connection.Open();
            var command = new MySqlCommand(
                "IncreaseLikesTest",
                connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("ideaID", MySqlDbType.Int32).Value = 18;

            var result = command.ExecuteScalar();
            connection.Close();

            return (int)result;
        }

        private static int GetNumber()
        {
            var connection = new MySqlConnection(SqlToolFactory.ConnectionString);
            connection.Open();
            var command = new MySqlCommand(
                "SELECT integerNumber FROM test WHERE id = 18;",
                connection);

            var result = command.ExecuteScalar();
            connection.Close();

            return (int) result;
        }
    }
}