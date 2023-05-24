namespace Backend_OddityVR.Domain.Associative_Tables.Article
{
    public class Author
    {
        // Associative table, users who wrote the article
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
