using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class ArticleAppService : IArticleAppService
    {
        // properties
        private readonly ArticleRepo _articleRepo;


        // constructor
        public ArticleAppService(ArticleRepo articleRepo)
        {
            _articleRepo = articleRepo;
        }


        // create
        public void CreateNewArticle(CreateArticleCmd newArticle)
        {
            Article article = newArticle.ToModel();
            _articleRepo.CreateNewArticle(article);
        }


        // get all
        public List<Article> GetAllArticles()
        {
            return _articleRepo.GetAllArticles();
        }


        // get id
        public Article GetArticleById(int id)
        {
            return _articleRepo.GetArticleById(id);
        }


        // update
        public void UpdateArticle(CreateArticleCmd updateArticle, int id)
        {
            Article article = updateArticle.ToModel(id);
            _articleRepo.UpdateArticle(article);
        }


        // delete
        public void DeleteArticle(int id)
        {
            _articleRepo.DeleteArticle(id);
        }
    }
}
