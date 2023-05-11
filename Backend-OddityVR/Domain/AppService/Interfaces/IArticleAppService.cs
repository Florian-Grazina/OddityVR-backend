using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface IArticleAppService
    {
        public void CreateNewArticle(CreateArticleCmd newArticle);
        public List<Article> GetAllArticles();
        public Article GetArticleById(int id);
        public void UpdateArticle(CreateArticleCmd updateArticle, int id);
        public void DeleteArticle(int id);
    }
}
