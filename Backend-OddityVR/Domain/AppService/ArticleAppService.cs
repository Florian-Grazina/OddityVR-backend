using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;

namespace Backend_OddityVR.Domain.AppService
{
    public class ArticleAppService
    {
        // properties
        private readonly ArticleRepo _articleRepo;


        // constructor
        public ArticleAppService()
        {
            _articleRepo = new();
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
