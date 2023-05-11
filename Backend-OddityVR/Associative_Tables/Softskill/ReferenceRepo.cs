using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Associative_Tables.Softskill
{
    public class ReferenceRepo
    {
        // properties
        private readonly Database _database;


        // constructor
        public ReferenceRepo()
        {
            _database = Database.GetInstance();
        }


        // create
        public void CreateNewReference(Reference reference)
        {
            string query =
                "INSERT INTO Softskill_Reference (Id_Test, Id_Softskill, Value) " +
                "VALUES (@TestId, @SoftskillId, @Value)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, reference);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Reference> GetAllReferences()
        {
            string query =
                "SELECT * " +
                "FROM softskill_Reference";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Reference> references = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return references;
        }


        // get id
        public List<Reference> GetReferenceByTestId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill_Reference " +
                "WHERE Id_Test = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Reference> references = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return references;
        }


        public List<Reference> GetReferenceBySoftskillId(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill_Reference " +
                "WHERE Id_Softskill = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Reference> reference = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return reference;
        }


        // update
        public void UpdateReference(Reference reference, int testId, int softskillId)
        {
            string query =
                "UPDATE Softskill_Reference " +
                "SET Id_Test = @TestId, Id_Softskill = @SoftskillId, Value = @Value " +
                "WHERE Id_Test = @TestToModify AND Id_Softskill = @SoftskillToModify";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, reference);
            command.Parameters.AddWithValue("@TestToModify", testId);
            command.Parameters.AddWithValue("@SoftskillToModify", softskillId);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteReferenceByTestId(int id)
        {
            string query =
                "DELETE FROM Softskill_Reference " +
                "WHERE Id_Test = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();
        }


        public void DeleteReferenceBySoftskillId(int id)
        {
            string query =
                "DELETE FROM Softskill_Reference " +
                "WHERE Id_Softskill = @Id";
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
        public List<Reference> ToModel(SqlDataReader reader)
        {
            List<Reference> listReferences = new();
            while (reader.Read())
            {
                listReferences.Add(new Reference()
                {
                    TestId = int.Parse(reader["Id_Test"].ToString()),
                    SoftskillId = int.Parse(reader["Id_Softskill"].ToString()),
                    Value = int.Parse(reader["Value"].ToString())
                });
            }
            return listReferences;
        }

        public SqlCommand AddParameters(SqlCommand command, Reference Reference)
        {
            command.Parameters.AddWithValue("@TestId", Reference.TestId);
            command.Parameters.AddWithValue("@SoftskillId", Reference.SoftskillId);
            command.Parameters.AddWithValue("@Value", Reference.Value);

            return command;
        }
    }
}
