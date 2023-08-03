using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
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

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, newSoftskill);

            command.ExecuteNonQuery();
        }


        // get all
        public List<Softskill> GetAllSoftskills()
        {
            string query =
            "SELECT * " +
            "FROM Softskill";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Softskill> softSkills = ToModel(sqlReader);

            return softSkills;
        }


        // get id
        public Softskill GetSoftskillById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Softskill " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            Softskill softSkill = ToModel(sqlReader).First();

            return softSkill;
        }


        // update
        public void UpdateSoftskill(Softskill Softskill)
        {
            string query =
                "UPDATE Softskill SET " +
                "Name = @Name " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, Softskill);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteSoftskill(int id)
        {
            string query =
                "DELETE FROM Softskill " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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
    }
}
