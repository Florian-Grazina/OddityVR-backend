using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Service
{
    public class Database
    {
        // properties

        private static SqlConnection DbConnection;

        private static IConfiguration _configuration;


        // constructor
        public Database(IConfiguration config)
        {
            _configuration = config;
            DbConnection = new(_configuration["DataSource"]);
            DbConnection.Open();
            Console.WriteLine("Connection opened");
        }


        // methods
        public SqlConnection GetDbConnection()
        {
            return DbConnection;
        }
    }
}
