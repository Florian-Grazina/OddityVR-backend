using Backend_OddityVR.Service;
using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class DepartmentRepo : AbstractRepo
    {
        // constructor
        public DepartmentRepo(Database database) : base(database)
        {
        }


        // create
        public Department CreateNewDepartment(Department department)
        {
            string query =
                "INSERT INTO Department " +
                "(Name, Id_Company) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@Name, @CompanyId)";

            using SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, department);

            int departmentId = (int)command.ExecuteScalar();

            return GetDepartmentById(departmentId);
        }


        // get all
        public List<Department> GetAllDepartments()
        {
            string query =
                "SELECT * " +
                "FROM Department";

            using SqlCommand command = new(query, _database.GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Department> departments = ToModel(sqlReader);

            return departments;
        }


        // get id
        public Department GetDepartmentById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Department " +
                "WHERE ID = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            Department department = ToModel(sqlReader).First();

            return department;
        }


        // get by company id
        public List<Department> GetDepartmentByCompanyId(int id)
        {
            string query =
                "SELECT * FROM Department " +
                "INNER JOIN Company " +
                "ON Department.Id_Company = Company.Id " +
                "WHERE Id_Company = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Department> departments = ToModel(sqlReader);

            return departments;
        }


        // update
        public void UpdateDepartment(Department Department)
        {
            string query =
                "UPDATE Department " +
                "SET Name = @Name, Id_Company = @CompanyId " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, Department);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteDepartment(int id)
        {
            string query =
                "DELETE FROM Department " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }

        // methods
        public List<Department> ToModel(SqlDataReader reader)
        {
            List<Department> listDepartments = new();
            while (reader.Read())
            {
                listDepartments.Add(new Department()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    CompanyId = int.Parse(reader["Id_Company"].ToString())
                });
            }
            return listDepartments;
        }

        public SqlCommand AddParameters(SqlCommand command, Department department)
        {
            command.Parameters.AddWithValue("@Name", department.Name);
            command.Parameters.AddWithValue("@CompanyId", department.CompanyId);
            if (department.Id != null)
                command.Parameters.AddWithValue("@Id", department.Id);

            return command;
        }
    }
}
