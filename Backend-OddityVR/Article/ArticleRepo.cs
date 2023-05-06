using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Article
{
    public class ArticleRepo
    {
        // properties
        private readonly Database _database;


        // constructor
        public ArticleRepo()
        {
            _database = Database.GetInstance();
        }


        // create
        public void CreateNewArticle(Article article)
        {
            string query =
                "INSERT INTO Article " +
                "(DatePublished, IsPublished, Title, Body, IsPublic) " +
                "VALUES (@DatePublished, @IsPublished, @Title, @Body, @IsPublic)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, article);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Article> GetAllArticles()
        {
            string query =
                "SELECT * " +
                "FROM Article";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Article> articles = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return articles;
        }


        // get id
        public Article GetArticleById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Article " +
                "WHERE Id = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            Article article = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return article;
        }


        // update
        public void UpdateArticle(Article article)
        {
            string query =
                "UPDATE Article SET " +
                "DatePublished = @Datepublished, IsPublished = @IsPublished, Title = @Title, Body = @Body, IsPublic = @IsPublic " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, article);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteArticle(int id)
        {
            string query =
                "DELETE FROM Article " +
                "WHERE Id = @Id";
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
        public List<Article> ToModel(SqlDataReader reader)
        {
            List<Article> listArticles = new();
            while (reader.Read())
            {
                Console.WriteLine(reader["IsPublished"]);
                listArticles.Add(new Article()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Body = reader["Body"].ToString(),
                    DatePublished = DateTime.Now,
                    IsPublished = bool.Parse(reader["IsPublished"].ToString()),
                    IsPublic = bool.Parse(reader["IsPublic"].ToString()),
                });
            }
            return listArticles;
        }


        public SqlCommand AddParameters(SqlCommand command, Article article)
        {
            command.Parameters.AddWithValue("@DatePublished", article.DatePublished);
            command.Parameters.AddWithValue("@IsPublished", article.IsPublished);
            command.Parameters.AddWithValue("@Title", article.Title);
            command.Parameters.AddWithValue("@Body", article.Body);
            command.Parameters.AddWithValue("@IsPublic", article.IsPublic);
            if (article.Id != null)
                command.Parameters.AddWithValue("@Id", article.Id);

            return command;
        }
    }
}
