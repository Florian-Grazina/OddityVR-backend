using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Domain.Associative_Tables.Article
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController
    {
        // properties
        private readonly AuthorAppService _authorService;


        // constructor
        public AuthorController(AuthorAppService authorAppService)
        {
            _authorService = authorAppService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewAuthor(Author author)
        {
            _authorService.CreateNewAuthor(author);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Author> GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }


        [Route("get_article/{id:int}")]
        [HttpGet]
        public List<Author> GetAuthorByUserId(int id)
        {
            return _authorService.GetAuthorByUserId(id);
        }


        [Route("get_user/{id:int}")]
        [HttpGet]
        public List<Author> GetAuthorByArticleId(int id)
        {
            return _authorService.GetAuthorByArticleId(id);
        }


        [Route("update/{userId:int},{articleId:int}")]
        [HttpPut]
        public void UpdateAuthor(Author author, int userId, int articleId)
        {
            _authorService.UpdateAuthor(author, userId, articleId);
        }


        [Route("delete_user/{id:int}")]
        [HttpDelete]
        public void DeleteAuthorByUserId(int id)
        {
            _authorService.DeleteAuthorByUserId(id);
        }


        [Route("delete_article/{id:int}")]
        [HttpDelete]
        public void DeleteAuthorByArticleId(int id)
        {
            _authorService.DeleteAuthorByArticleId(id);
        }
    }
}
