namespace Backend_OddityVR.Domain.Model
{
    public class Article : IModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime? DatePublished { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPublic { get; set; }
    }
}
