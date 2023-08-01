using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo.Interfaces;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public class RoleRepo : AbstractRepo
    {
        // constructor
        public RoleRepo(Database database) : base(database)
        {
        }


        // create
        public Role CreateNewRole(Role role)
        {
            string query =
                "INSERT INTO Role (Name) " +
                "VALUES (@Name)";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, role);

            int roleId = command.ExecuteNonQuery();

            return GetRoleById(roleId);
        }


        // get all
        public List<Role> GetAllRoles()
        {
            string query =
                "SELECT * " +
                "FROM Role";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Role> roles = ToModel(sqlReader);

            return roles;
        }


        // get id
        public Role GetRoleById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Role " +
                "WHERE ID = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            Role role = ToModel(sqlReader).First();

            return role;
        }


        // update
        public void UpdateRole(Role role)
        {
            string query =
                "UPDATE Role " +
                "SET Name = @Name " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, role);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteRole(int id)
        {
            string query =
                "DELETE FROM Role " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
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
    }
}
