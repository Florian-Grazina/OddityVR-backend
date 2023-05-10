using Newtonsoft.Json;

namespace Backend_OddityVR.Associative_Tables.Article
{
    public class AuthorAppService
    {
        // properties
        private readonly AuthorRepo _authorRepo;


        // constructor
        public AuthorAppService()
        {
            _authorRepo = new();
        }


        // create
        public void CreateNewAuthor(Author author)
        {
            _authorRepo.CreateNewAuthor(author);
        }


        // get all
        public List<Author> GetAllAuthors()
        {
            return _authorRepo.GetAllAuthors();
        }


        // get id
        public List<Author> GetAuthorByUserId(int id)
        {
            return _authorRepo.GetAuthorByUserId(id);
        }


        public List<Author> GetAuthorByArticleId(int id)
        {
            return _authorRepo.GetAuthorByArticleId(id);
        }


        // update
        public void UpdateAuthor(Author updateAuthor, int userId, int articleId)
        {
            _authorRepo.UpdateAuthor(updateAuthor, userId, articleId);
        }


        // delete
        public void DeleteAuthorByUserId(int id)
        {
            _authorRepo.DeleteAuthorByUserId(id);
        }


        public void DeleteAuthorByArticleId(int id)
        {
            _authorRepo.DeleteAuthorByArticleId(id);
        }
    }
}
