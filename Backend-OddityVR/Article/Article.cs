namespace Backend_OddityVR.Article
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime? DatePublished { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPublic { get; set; }
    }
}
