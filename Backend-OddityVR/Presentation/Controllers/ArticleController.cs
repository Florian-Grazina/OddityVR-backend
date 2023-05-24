using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Presentation.Controllers
{
    [Route("api/article")]
    [ApiController]
    public class ArticleController
    {
        // properties
        private readonly IArticleAppService _articleService;


        // constructor
        public ArticleController(IArticleAppService articleService)
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
        [HttpPut]
        public void UpdateArticle(CreateArticleCmd updateArticle, int id)
        {
            _articleService.UpdateArticle(updateArticle, id);
        }


        [Route("delete/{id:int}")]
        [HttpDelete]
        public void DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
        }
    }
}
