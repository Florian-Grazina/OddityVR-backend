using System.ComponentModel.DataAnnotations;

namespace Backend_OddityVR.Article.DTO
{
    public class CreateArticleCmd
    {
        // properties
        [Required(ErrorMessage = "Article title is mandatory")]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePublished { get; set; }
        public bool IsPublished { get; set; }
        public bool IsPublic { get; set; }


        // constructor
        public CreateArticleCmd() { }


        // methods
        public Article ToModel(int id = 0)
        {
            return new Article
            {
                Id = id,
                Title = this.Title,
                Body = this.Body,
                DatePublished = this.DatePublished,
                IsPublished = this.IsPublished,
                IsPublic = this.IsPublic,
            };
        }
    }
}
