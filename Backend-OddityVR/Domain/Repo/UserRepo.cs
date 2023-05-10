using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class UserRepo : AbstractRepo
    {
        // create
        public void CreateNewUser(User user)
        {
            string query =
                "INSERT INTO End_User " +
                "(Email, Password, Birthdate, Id_Role, Id_Department) " +
                "VALUES (@Email, @Password, @Birthdate, @RoleId, @DepartmentId)";

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
                "FROM End_User";

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
                "FROM End_User " +
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
                "UPDATE End_User SET " +
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
                    LastConnection = DateTime.TryParse(reader["Last_Connection"].ToString(), out DateTime dateResult) ? dateResult : null,
                    RoleId = int.Parse(reader["Id_Role"].ToString()),
                    DepartmentId = int.Parse(reader["Id_department"].ToString())
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
