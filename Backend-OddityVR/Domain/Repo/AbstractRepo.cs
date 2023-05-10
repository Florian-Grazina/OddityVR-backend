using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public abstract class AbstractRepo
    {
        // properties
        protected readonly Database _database;


        // constructor
        public AbstractRepo()
        {
            _database = Database.GetInstance();
        }


        // method
        //public void ExecuteQuery(SqlCommand command, Func method)
        //{
        //    _database.GetDbConnection().Open();

        //    SqlDataReader sqlReader = command.ExecuteReader();
        //    method(sqlReader);

        //    _database.GetDbConnection().Close();
        //}
    }
}
