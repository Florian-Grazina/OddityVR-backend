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
        public Article? CreateNewArticle(Article article)
        {
            string query =
                "INSERT INTO Article " +
                "(Date_Published, Is_Published, Title, Body, Is_Public) " +
                "VALUES (@DatePublished, @IsPublished, @Title, @Body, @IsPublic)";
            
            using SqlCommand command = new(query, _database.GetDbConnection());
            RepoHelper.AddParameters(command, article);

            int articleId = (int) command.ExecuteScalar();

            return GetArticleById(articleId);
        }


        // get all
        public List<Article> GetAllArticles()
        {
            string query =
                "SELECT * " +
                "FROM Article";

            using SqlCommand command = new(query, _database.GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Article> articles = ToModel(sqlReader);

            return articles;
        }


        // get id
        public Article? GetArticleById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Article " +
                "WHERE Id = @Id";
            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            Article? article = ToModel(sqlReader).FirstOrDefault();

            return article;
        }


        // update
        public void UpdateArticle(Article article)
        {
            string query =
                "UPDATE Article SET " +
                "Date_Published = @Datepublished, Is_Published = @IsPublished, Title = @Title, Body = @Body, Is_Public = @IsPublic " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            RepoHelper.AddParameters(command, article);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteArticle(int id)
        {
            string query =
                "DELETE FROM Article " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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
    }
}
