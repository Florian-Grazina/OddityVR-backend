using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public class UserRepo : AbstractRepo
    {
        // constructor
        public UserRepo(Database database) : base(database)
        {
        }


        // create
        public User CreateNewUser(User user)
        {
            string query =
                "INSERT INTO End_User " +
                "(Email, Password, Birthdate, Id_Role, Id_Department) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@Email, @Password, @Birthdate, @RoleId, @DepartmentId)";

            using SqlCommand command = new(query, _database.GetDbConnection());
            RepoHelper.AddParameters(command, user);

            int userId = (int)command.ExecuteScalar();

            return GetUserById(userId);
        }


        // get all
        public List<User> GetAllUser()
        {
            string query =
                "SELECT * " +
                "FROM End_User";

            using SqlCommand command = new(query, _database.GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<User> listUsers = ToModel(sqlReader);

            return listUsers;
        }


        // get all from company
        public List<User> GetAllUserFromCompanyId(int id)
        {
            string query =
                "SELECT * " +
                "FROM End_User " +
                "INNER JOIN Department " +
                "ON Department.Id = End_User.Id_Department " +
                "WHERE Department.Id_Company = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<User> listUsers = ToModel(sqlReader);

            return listUsers;
        }


        // get all from company
        public List<User> GetAllUsersFromDepartmentId(int id)
        {
            string query =
                "SELECT * " +
                "FROM End_User " +
                "WHERE Id_Department = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<User> listUsers = ToModel(sqlReader);

            return listUsers;
        }


        // get id
        public User GetUserById(int id)
        {
            string query =
                "SELECT * " +
                "FROM End_User " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            User user = ToModel(sqlReader).First();

            return user;
        }


        // update
        public void UpdateUser(User user)
        {
            string query =
                "UPDATE End_User SET " +
                "Email = @Email, Password = @Password, Birthdate = @Birthdate, Id_Role = @RoleId, Id_Department = @DepartmentId " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            RepoHelper.AddParameters(command, user);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteUser(int id)
        {
            string query =
                "DELETE FROM End_User " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }


        // Login
        public User? Login(User loginUser)
        {
            string query =
                "SELECT * FROM End_User " +
                "WHERE Password = @Password AND Email = @Email";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Password", loginUser.Password);
            command.Parameters.AddWithValue("@Email", loginUser.Email);

            using SqlDataReader sqlReader = command.ExecuteReader();
            User? user = ToModel(sqlReader).FirstOrDefault();

            return user;
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
    }
}
