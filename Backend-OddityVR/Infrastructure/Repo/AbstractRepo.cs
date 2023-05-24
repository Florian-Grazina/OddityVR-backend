using Backend_OddityVR.Domain.Service;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public abstract class AbstractRepo
    {
        // properties
        protected readonly Database _database;


        // constructor
        public AbstractRepo(Database database)
        {
            //_database = Database.GetInstance();
            _database = database;
        }
    }
}
