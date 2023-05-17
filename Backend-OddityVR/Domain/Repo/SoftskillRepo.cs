using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Model;
using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace BackOddityVR.Domain.Repo
{
    public class SoftskillRepo : AbstractRepo
    {
        // constructor
        public SoftskillRepo(Database database) : base(database)
        {
        }


        // create
        public void CreateNewSoftskill(Softskill newSoftskill)
        {
            string query =
                "INSERT INTO Softskill " +
                "(Name) " +
                "VALUES (@Name)";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, newSoftskill);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Softskill> GetAllSoftskills()
        {
            string query =
            "SELECT * " +
            "FROM Softskill";

            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Softskill> listSoftskills = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return listSoftskills;
        }


        // get id
        public Softskill GetSoftskillById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            Softskill Softskill = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return Softskill;
        }


        // update
        public void UpdateSoftskill(Softskill Softskill)
        {
            string query =
                "UPDATE Softskill SET " +
                "Name = @Name " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, Softskill);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteSoftskill(int id)
        {
            string query =
                "DELETE FROM Softskill " +
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
        private List<Softskill> ToModel(SqlDataReader reader)
        {
            List<Softskill> listSoftskills = new();
            while (reader.Read())
            {
                listSoftskills.Add(new Softskill()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                });
            }
            return listSoftskills;
        }


        public SqlCommand AddParameters(SqlCommand command, Softskill softskill)
        {
            command.Parameters.AddWithValue("@Name", softskill.Name);

            // only needed for updating
            if (softskill.Id != null)
                command.Parameters.AddWithValue("@Id", softskill.Id);

            return command;
        }
    }
}
