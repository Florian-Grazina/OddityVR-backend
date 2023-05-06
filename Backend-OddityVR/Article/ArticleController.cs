using Backend_OddityVR.Article.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Backend_OddityVR.Article
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController
    {
        // properties
        private readonly ArticleAppService _articleService;


        // constructor
        public ArticleController(ArticleAppService articleService)
        {
            _articleService = articleService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewArticle(CreateArticleCmd newArticleCmd)
        {
            _articleService.CreateNewArticle(newArticleCmd);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Article> GetAllArticles()
        {
            return _articleService.GetAllArticles();
        }


        [Route("get/{id:int}")]
        [HttpGet]
        public Article GetArticle(int id)
        {
            return _articleService.GetArticleById(id);
        }


        [Route("update/{id:int}")]
        [HttpPost]
        public void UpdateArticle(CreateArticleCmd updateArticle, int id)
        {
            _articleService.UpdateArticle(updateArticle, id);
        }


        [Route("delete/{id:int}")]
        [HttpGet]
        public void DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
        }
    }
}
