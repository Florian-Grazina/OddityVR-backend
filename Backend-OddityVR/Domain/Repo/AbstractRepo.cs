using Backend_OddityVR.Service;

namespace Backend_OddityVR.Domain.Repo
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
