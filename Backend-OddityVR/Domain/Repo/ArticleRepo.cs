using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class ArticleRepo : AbstractRepo
    {
        // constructor
        public ArticleRepo(Database database) : base(database)
        {
        }


        // create
        public void CreateNewArticle(Article article)
        {
            string query =
                "INSERT INTO Article " +
                "(Date_Published, Is_Published, Title, Body, Is_Public) " +
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
                "Date_Published = @Datepublished, Is_Published = @IsPublished, Title = @Title, Body = @Body, Is_Public = @IsPublic " +
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
                listArticles.Add(new Article()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Body = reader["Body"].ToString(),
                    DatePublished = DateTime.Now,
                    IsPublished = bool.Parse(reader["Is_Published"].ToString()),
                    IsPublic = bool.Parse(reader["Is_Public"].ToString()),
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
