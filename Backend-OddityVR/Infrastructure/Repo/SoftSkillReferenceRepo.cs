using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo.Interfaces;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public class SoftSkillReferenceRepo : AbstractRepo
    {
        public SoftSkillReferenceRepo(Database database) : base(database)
        {
        }


        // create
        public void CreateNewReference(SoftSkillReference reference)
        {
            string query =
                "INSERT INTO Softskill_Reference (Id_Test, Id_Softskill, Value) " +
                "VALUES (@TestId, @SoftskillId, @Value)";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, reference);

            command.ExecuteNonQuery();
        }


        // get all
        public List<SoftSkillReference> GetAllReferences()
        {
            string query =
                "SELECT * " +
                "FROM softskill_Reference";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<SoftSkillReference> softSkillsReference = ToModel(sqlReader);

            return softSkillsReference;
        }


        // get id
        public List<SoftSkillReference> GetReferenceByTestId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill_Reference " +
                "WHERE Id_Test = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<SoftSkillReference> softSkillsReference = ToModel(sqlReader);

            return softSkillsReference;
        }


        public List<SoftSkillReference> GetReferenceBySoftskillId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill_Reference " +
                "WHERE Id_Softskill = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<SoftSkillReference> softSkillsReference = ToModel(sqlReader);

            return softSkillsReference;
        }


        //// update
        //public void UpdateReference(SoftSkillReference reference, int testId, int softskillId)
        //{
        //    string query =
        //        "UPDATE Softskill_Reference " +
        //        "SET Id_Test = @TestId, Id_Softskill = @SoftskillId, Value = @Value " +
        //        "WHERE Id_Test = @TestToModify AND Id_Softskill = @SoftskillToModify";
        //    SqlCommand command = new(query, GetDatabase().GetDbConnection());
        //    AddParameters(command, reference);
        //    command.Parameters.AddWithValue("@TestToModify", testId);
        //    command.Parameters.AddWithValue("@SoftskillToModify", softskillId);

        //    // Starting connection with DB and executing
        //    GetDatabase().GetDbConnection().Open();

        //    SqlDataReader sqlReader = command.ExecuteReader();

        //    GetDatabase().GetDbConnection().Close();
        //    sqlReader.Close();
        //    command.Connection.Close();
        //}


        // delete
        public void DeleteReferenceByTestId(int id)
        {
            string query =
                "DELETE FROM Softskill_Reference " +
                "WHERE Id_Test = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }


        public void DeleteReferenceBySoftskillId(int id)
        {
            string query =
                "DELETE FROM Softskill_Reference " +
                "WHERE Id_Softskill = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }


        // methods
        public List<SoftSkillReference> ToModel(SqlDataReader reader)
        {
            List<SoftSkillReference> listReferences = new();
            while (reader.Read())
            {
                listReferences.Add(new SoftSkillReference()
                {
                    TestId = int.Parse(reader["Id_Test"].ToString()),
                    SoftskillId = int.Parse(reader["Id_Softskill"].ToString()),
                    Value = int.Parse(reader["Value"].ToString())
                });
            }
            return listReferences;
        }
    }
}
