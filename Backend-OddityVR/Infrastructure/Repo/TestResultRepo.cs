using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo.Interfaces;
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
        public void CreateNewTestResult(TestResult testResult)
        {
            string query =
                "INSERT INTO Test_Result (Sharing, Summary, Id_Batch, Id_User) " +
                "VALUES (@Sharing, @Summary, @BatchId, @UserId)";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, testResult);

            command.ExecuteNonQuery();
        }


        // get all
        public List<TestResult> GetAllTestResults()
        {
            string query =
                "SELECT * " +
                "FROM Test_Result";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<TestResult> testResults = ToModel(sqlReader);

            return testResults;
        }


        // get id
        public TestResult GetTestResultById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Test_Result " +
                "WHERE ID = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            TestResult testResult = ToModel(sqlReader).First();

            return testResult;
        }


        public List<SoftSkillReference> GetSoftskillReferenceByUser(int id)
        {
            string query =
                "SELECT Id_Test, softskill.Name, Value_result FROM Softskill_reference " +
                "INNER JOIN softskill ON softskill.Id = Id_SoftSkill " +
                "WHERE Id_Test = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<SoftSkillReference> softSkillReferences= ToModelReference(sqlReader);

            return softSkillReferences;
        }


        // update
        public void UpdateTestResult(TestResult testResult)
        {
            string query =
                "UPDATE Test_Result " +
                "SET Id_User = @UserId, Sharing = @Sharing, Summary = @Summary, Id_Batch = @BatchId " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, testResult);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteTestResult(int id)
        {
            string query =
                "DELETE FROM Test_Result " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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

        public List<SoftSkillReference> ToModelReference(SqlDataReader reader)
        {
            List<SoftSkillReference> listTestResults = new();
            while (reader.Read())
            {
                listTestResults.Add(new SoftSkillReference()
                {
                    TestId = int.Parse(reader["Id_Test"].ToString()),
                    SoftskillId = int.Parse(reader["Id_Test"].ToString()),
                    Value = int.Parse(reader["Id_Test"].ToString())
                });
            }
            return listTestResults;
        }
    }
}
