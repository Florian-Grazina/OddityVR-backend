using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public class TestResultRepo : AbstractRepo
    {
        // constructor
        public TestResultRepo(Database database) : base(database)
        {
        }


        // create
        public void CreateNewTestResult(TestResult TestResult)
        {
            string query =
                "INSERT INTO Test_Result (Sharing, Summary, Id_Batch, Id_User) " +
                "VALUES (@Sharing, @Summary, @BatchId, @UserId)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, TestResult);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<TestResult> GetAllTestResults()
        {
            string query =
                "SELECT * " +
                "FROM Test_Result";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<TestResult> testResults = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return testResults;
        }


        // get id
        public TestResult GetTestResultById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Test_Result " +
                "WHERE ID = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            TestResult TestResult = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return TestResult;
        }


        // update
        public void UpdateTestResult(TestResult testResult)
        {
            string query =
                "UPDATE Test_Result " +
                "SET Id_User = @UserId, Sharing = @Sharing, Summary = @Summary, Id_Batch = @BatchId " +
                "WHERE Id = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, testResult);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteTestResult(int id)
        {
            string query =
                "DELETE FROM Test_Result " +
                "WHERE Id = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();
        }

        // methods
        public List<TestResult> ToModel(SqlDataReader reader)
        {
            List<TestResult> listTestResults = new();
            while (reader.Read())
            {
                listTestResults.Add(new TestResult()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Sharing = bool.Parse(reader["Sharing"].ToString()),
                    Summary = reader["Summary"].ToString(),
                    BatchId = int.Parse(reader["Id_Batch"].ToString()),
                    UserId = int.Parse(reader["Id_User"].ToString()),
                });
            }
            return listTestResults;
        }

        public SqlCommand AddParameters(SqlCommand command, TestResult testResult)
        {
            command.Parameters.AddWithValue("@Sharing", testResult.Sharing);
            command.Parameters.AddWithValue("@Summary", testResult.Summary);
            command.Parameters.AddWithValue("@BatchId", testResult.BatchId);
            command.Parameters.AddWithValue("@UserId", testResult.UserId);
            if (testResult.Id != null)
                command.Parameters.AddWithValue("@Id", testResult.Id);

            return command;
        }
    }
}
