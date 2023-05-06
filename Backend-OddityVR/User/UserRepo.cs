using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.User
{
    public class UserRepo
    {
        // properties
        private readonly Database _database;


        // constructor
        public UserRepo ()
        {
            _database = Database.GetInstance();
        }


        // create
        public void CreateNewUser(User user)
        {
            string query =
                "INSERT INTO User " +
                "(Email, Password, Birthdate, Id_Role, Id_Department) " +
                "VALUES (@Email, @Password, @Birthdate, @Id_Role, @Id_Department)";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, user);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<User> GetAllUser()
        {
            string query =
                "SELECT * " +
                "FROM Prospe";

            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<User> listUsers = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return listUsers;
        }


        // get id
        public User GetUserById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Prospe " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            User user = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return user;
        }


        // update
        public void UpdateUser(User user)
        {
            string query =
                "UPDATE User SET " +
                "Email = @Email, Password = @Password, Birthdate = @Birthdate, Id_Role = @RoleId, Id_Department = @DepartmentId " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, user);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteUser(int id)
        {
            string query =
                "DELETE FROM End_User " +
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
        private List<User> ToModel(SqlDataReader reader)
        {
            List<User> listUsers = new();
            while (reader.Read())
            {
                listUsers.Add(new User()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    Birthdate = DateTime.Parse(reader["Birthdate"].ToString()),
                    LastConnection = DateTime.TryParse(reader["LastConnection"].ToString(), out DateTime dateResult) ? dateResult : null,
                    RoleId = int.Parse(reader["RoleId"].ToString()),
                    DepartmentId = int.Parse(reader["DepartmentId"].ToString())
                });
            }
            return listUsers;
        }


        public SqlCommand AddParameters(SqlCommand command, User user)
        {
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Birthdate", user.Birthdate);
            command.Parameters.AddWithValue("@RoleId", user.RoleId);
            command.Parameters.AddWithValue("@DepartmentId", user.DepartmentId);

            // only needed for updating
            if (user.Id != null)
                command.Parameters.AddWithValue("@Id", user.Id);

            return command;
        }
    }
}
