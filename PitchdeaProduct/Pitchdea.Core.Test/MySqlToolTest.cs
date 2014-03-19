using System;
using System.Linq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using Pitchdea.Core.Model;
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
            _sqlTestTool.CleanTestDb();

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
        }
        
        [Test]
        public void _02_QueryEmptyTable()
        {
            _sqlTestTool.CleanTestDb();

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
        }

        [Test]
        public void _03_InsertAndFetchIdea()
        {
            _sqlTestTool.CleanTestDb();

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            InsertAndFetch(title, summary, description, question);
        }
        
        [Test]
        public void _04_InsertAndFetchIdea_SpecialCharacters()
        {
            _sqlTestTool.CleanTestDb();

            const string title = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\nn \t asd";
            const string summary = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\nn \t asd";
            const string description = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\n \t asd";
            const string question = "`?=)(/&%¤#\"!@£$€{[]} \\ ~*'^ <> \r\n \t asd";

            InsertAndFetch(title, summary, description, question);
        }

        [Test]
        public void _05_TryToFetchIdeaThatDoesNotExist()
        {
            _sqlTestTool.CleanTestDb();

            var idea = _mySqlTool.FetchIdea("hash123");
            Assert.Null(idea);
        }

        [Test]
        public void _06_FindUserById()
        {
            _sqlTestTool.CleanTestDb();
            
            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            var fetchedUserName = _mySqlTool.FindUsername(userInfo.UserId);

            Assert.AreEqual(username, fetchedUserName);
        }

        [Test]
        public void _07_InsertAndFetchIdea_Multiline()
        {
            _sqlTestTool.CleanTestDb();

            const string title = "Multi-line";
            const string summary = "line1\r\nline2";
            const string description = "line1\r\nline2\r\n";
            const string question = "Question\r\nQuestion??";

            InsertAndFetch(title, summary, description, question);
        }

        [Test]
        public void _08_InsertAndFetchIdea_WithImage()
        {
            _sqlTestTool.CleanTestDb();

            const string title = "Multi-line";
            const string summary = "line1\r\nline2";
            const string description = "line1\r\nline2\r\n";
            const string question = "Question\r\nQuestion??";
            const string imagePath = "testImage.jpg";

            InsertAndFetch(title, summary, description, question, imagePath);
        }


        [Test]
        public void _09_InsertMultipleIdeasAndFetchAll()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);
            
            var title = "Multi-line";
            var summary = "line1\r\nline2";
            var description = "line1\r\nline2\r\n";
            var question = "Question\r\nQuestion??";
            const string imagePath = "testImage.jpg";
            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = imagePath };

            _mySqlTool.InsertIdea(idea);

            title = "qwerty";
            summary = "asdf";
            description = "jotain ihan muuta";
            question = "Question?";

            var idea2 = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };

            _mySqlTool.InsertIdea(idea2);

            var ideas = _mySqlTool.FetchAllIdeas();
            Assert.AreEqual(2, ideas.Count);
        }
        
        [Test]
        public void _10_LikeAnIdea_HasLiked()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };
            idea = _mySqlTool.InsertIdea(idea);

            Assert.AreEqual(0, idea.Likes);
            Assert.AreEqual(0, idea.Dislikes);

            var likeInfo = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Neutral, likeInfo);
            
            var result = _mySqlTool.Like(idea.Id, userInfo.UserId);
            Assert.AreEqual(1, result);

            var updatedIdea = _mySqlTool.FetchIdea(idea.Hash);

            Assert.AreEqual(1, updatedIdea.Likes);
            Assert.AreEqual(0, updatedIdea.Dislikes);

            var likeInfoAfter = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Like, likeInfoAfter);
        }


        [Test]
        public void _11_DislikeAnIdea()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };
            idea = _mySqlTool.InsertIdea(idea);

            Assert.AreEqual(0, idea.Likes);
            Assert.AreEqual(0, idea.Dislikes);

            var likeInfo = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Neutral, likeInfo);

            var result = _mySqlTool.Dislike(idea.Id, userInfo.UserId);
            Assert.AreEqual(1, result);

            var updatedIdea = _mySqlTool.FetchIdea(idea.Hash);

            Assert.AreEqual(0, updatedIdea.Likes);
            Assert.AreEqual(1, updatedIdea.Dislikes);

            var likeInfoAfter = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Dislike, likeInfoAfter);
        }

        [Test]
        public void _12_UnlikeAnIdea()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };
            idea = _mySqlTool.InsertIdea(idea);

            var result = _mySqlTool.Like(idea.Id, userInfo.UserId);
            Assert.AreEqual(1, result);

            var likeInfoAfter = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Like, likeInfoAfter);

            var result2 = _mySqlTool.Unlike(idea.Id, userInfo.UserId);
            Assert.AreEqual(0, result2);

            var likeInfo = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Neutral, likeInfo);
        }

        [Test]
        public void _13_UndislikeAnIdea()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };
            idea = _mySqlTool.InsertIdea(idea);

            var result = _mySqlTool.Dislike(idea.Id, userInfo.UserId);
            Assert.AreEqual(1, result);

            var likeInfoAfter = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Dislike, likeInfoAfter);

            var result2 = _mySqlTool.Undislike(idea.Id, userInfo.UserId);
            Assert.AreEqual(0, result2);

            var likeInfo = _mySqlTool.GetLikeStatus(idea.Id, userInfo.UserId);
            Assert.AreEqual(LikeStatus.Neutral, likeInfo);
        }

        [Test]
        public void _14_CommentOnAnIdea()
        {
            _sqlTestTool.CleanTestDb();

            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";

            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

            Assert.NotNull(userInfo);

            const string title = "qwerty";
            const string summary = "asdf";
            const string description = "jotain ihan muuta";
            const string question = "Question?";

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = null };
            idea = _mySqlTool.InsertIdea(idea);

            const string commentText = "This is a comment.";
            _mySqlTool.InsertComment(idea.Id, userInfo.UserId, commentText);

            var comments = _mySqlTool.FetchAllComments(idea.Id);

            Assert.AreEqual(1, comments.Count);
            var comment = comments.Single();
            Assert.AreEqual(idea.Id, comment.IdeaId);
            Assert.AreEqual(userInfo.UserId, comment.UserId);
            Assert.AreEqual(commentText, comment.Text);
            Assert.That(DateTime.Now.Subtract(comment.SubmitTime).TotalSeconds < 2); //Assume that the test doesn't take more than 2 seconds to complete.
        }

        private void InsertAndFetch(string title, string summary, string description, string question, string imagePath = null)
        {
            const string username = "test";
            const string email = "test@pitchdea.com";
            const string password = "password123";
            
            _auth.RegisterNewUser(username, email, password);
            var userInfo = _auth.Authenticate(email, password);

           Assert.NotNull(userInfo);

            var idea = new Idea(userInfo.UserId, title, summary, description, question) { ImagePath = imagePath};

            var insertedIdea = _mySqlTool.InsertIdea(idea);

            Assert.False(string.IsNullOrEmpty(insertedIdea.Hash));

            var connection = new MySqlConnection(SqlTestTool.TestConnectionString);
            connection.Open();
            var cmd = new MySqlCommand(
                string.Format("SELECT hash, title, summary, description, imagePath, userID FROM idea WHERE hash='{0}'", insertedIdea.Hash)
                , connection);

            cmd.Prepare();
            var reader = cmd.ExecuteReader();

            var result = new object[6];
            var canRead = reader.Read();

            try
            {
                result[0] = reader[0];
                result[1] = reader[1];
                result[2] = reader[2];
                result[3] = reader[3];
                result[4] = reader[4];
                result[5] = reader[5];
            }
            finally
            {
                connection.Close();
            }

            Assert.True(canRead);

            Assert.AreEqual(title, result[1]);
            Assert.AreEqual(summary, result[2]);
            Assert.AreEqual(description, result[3]);
            Assert.AreEqual(userInfo.UserId, result[5]);

            if (imagePath == null)
                Assert.True(result[4] is DBNull);
            else
                Assert.AreEqual(imagePath, result[4]);

            var fetchedIdea = _mySqlTool.FetchIdea(idea.Hash);

            Assert.AreEqual(idea.Hash, fetchedIdea.Hash);
            Assert.AreEqual(title, fetchedIdea.Title);
            Assert.AreEqual(summary, fetchedIdea.Summary);
            Assert.AreEqual(description, fetchedIdea.Description);
            Assert.AreEqual(imagePath, fetchedIdea.ImagePath);
            Assert.AreEqual(userInfo.UserId, fetchedIdea.UserId);
        }
    }
}
