using Backend_OddityVR.Domain.Service;

namespace Backend_OddityVR.Infrastructure.Repo.Interfaces
{
    public abstract class AbstractRepo
    {
        // properties
        private readonly Database _database;

        // constructor
        public AbstractRepo(Database database)
        {
            _database = database;
        }

        // methods
        protected Database GetDatabase()
        {
            return _database;
        }
    }
}
