using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
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
