using System.Data.SqlClient;

namespace Backend_OddityVR.Service
{
    public class Database
    {
        // TO DO
        // implement thread safe
        // DAO Factory

        // properties
        const string DataSource = @"Data Source=LAPTOP-704Q6RM8\SQLEXPRESS;Initial Catalog=Soft_Skills;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Database Instance;

        private static SqlConnection DbConnection;


        // constructor
        private Database()
        {
            DbConnection = new(DataSource);
        }


        // methods
        public static Database GetInstance()
        {
            Instance ??= new();
            return Instance;
        }

        public SqlConnection GetDbConnection()
        {
            return DbConnection;
        }
    }
}
