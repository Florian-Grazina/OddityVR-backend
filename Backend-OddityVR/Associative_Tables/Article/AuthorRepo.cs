using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Associative_Tables.Article
{
    public class AuthorRepo : AbstractRepo
    {
        public AuthorRepo(Database database) : base(database)
        {
        }


        // create
        public void CreateNewAuthor(Author author)
        {
            string query =
                "INSERT INTO Article_Author (Id_User, Id_Article) " +
                "VALUES (@UserId, @ArticleId)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, author);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Author> GetAllAuthors()
        {
            string query =
                "SELECT * " +
                "FROM Article_Author";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Author> authors = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return authors;
        }


        // get id
        public List<Author> GetAuthorByUserId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Article_Author " +
                "WHERE Id_User = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Author> authors = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return authors;
        }


        public List<Author> GetAuthorByArticleId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Article_Author " +
                "WHERE Id_Article = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Author> authors = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return authors;
        }


        // update
        public void UpdateAuthor(Author author, int userId, int articleId)
        {
            string query =
                "UPDATE Article_Author " +
                "SET Id_User = @UserId, Id_Article = @ArticleId " +
                "WHERE Id_User = @UserToModify AND Id_Article = @ArticleToModify";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, author);
            command.Parameters.AddWithValue("@UserToModify", userId);
            command.Parameters.AddWithValue("@ArticleToModify", articleId);


            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteAuthorByUserId(int id)
        {
            string query =
                "DELETE FROM Article_Author " +
                "WHERE Id_User = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();
        }


        public void DeleteAuthorByArticleId(int id)
        {
            string query =
                "DELETE FROM Article_Author " +
                "WHERE Id_Article = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();
        }


        // methods
        public List<Author> ToModel(SqlDataReader reader)
        {
            List<Author> listAuthors = new();
            while (reader.Read())
            {
                listAuthors.Add(new Author()
                {
                    UserId = int.Parse(reader["Id_User"].ToString()),
                    ArticleId = int.Parse(reader["Id_Article"].ToString()),
                });
            }
            return listAuthors;
        }

        public SqlCommand AddParameters(SqlCommand command, Author author)
        {
            command.Parameters.AddWithValue("@UserId", author.UserId);
            command.Parameters.AddWithValue("@ArticleId", author.ArticleId);

            return command;
        }
    }
}
