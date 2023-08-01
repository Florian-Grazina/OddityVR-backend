using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.DTO
{
    public class CreateArticleCmd
    {
        // properties
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
                Title = Title,
                Body = Body,
                DatePublished = DatePublished,
                IsPublished = IsPublished,
                IsPublic = IsPublic,
            };
        }
    }
}
