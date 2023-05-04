using Backend_OddityVR.Company;
using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Role
{
    public class RoleRepo
    {
        // properties
        private readonly Database _database;


        // constructor
        public RoleRepo()
        {
            _database = Database.GetInstance();
        }


        // create
        public void CreateNewRole(Role role)
        {
            string query =
                "INSERT INTO Role (Name) " +
                "VALUES (@name)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, role);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Role> GetAllRoles()
        {
            string query =
                "SELECT * " +
                "FROM Role";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Role> roles = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return roles;
        }


        // get id
        public Role GetRoleById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Role " +
                "WHERE ID = @id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            Role role = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return role;
        }


        // update
        public void UpdateRole(Role role)
        {
            string query =
                "UPDATE Role " +
                "SET Name = @name " +
                "WHERE Id = @id";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, role);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteRole(int id)
        {
            string query =
                "DELETE FROM Role " +
                "WHERE Id = @id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();
        }


        // methods
        public List<Role> ToModel(SqlDataReader reader)
        {
            List<Role> listRoles = new();
            while (reader.Read())
            {
                listRoles.Add(new Role()
                {
                    Name = reader["Name"].ToString(),
                    Id = int.Parse(reader["Id"].ToString())
                });
            }
            return listRoles;
        }

        public static SqlCommand AddParameters(SqlCommand command, Role role)
        {
            command.Parameters.AddWithValue("@Name", role.Name);
            if (role.Id != null)
                command.Parameters.AddWithValue("@Id", role.Id);

            return command;
        }
    }
}
