using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Domain.Service;
using Backend_OddityVR.Infrastructure.Repo.Interfaces;
using System.Data.SqlClient;

namespace Backend_OddityVR.Infrastructure.Repo
{
    public class CompanyRepo : AbstractRepo
    {
        // constructor
        public CompanyRepo(Database database) : base(database)
        {
        }


        // create
        public Company? CreateNewCompany(Company company)
        {
            string query =
                "INSERT INTO Company " +
                "(Name, Number, Street, City, Postal_Code, Country) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@Name, @Number, @Street, @City, @PostalCode, @Country)";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, company);

            int companyId = (int)command.ExecuteScalar();

            return GetCompanyById(companyId);
        }


        // get all
        public List<Company> GetAllCompanies()
        {
            string query =
                "SELECT * " +
                "FROM Company";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());

            using SqlDataReader sqlReader = command.ExecuteReader();
            List<Company> companies = ToModel(sqlReader);

            return companies;
        }


        // get id
        public Company? GetCompanyById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Company " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader sqlReader = command.ExecuteReader();
            Company? company = ToModel(sqlReader).FirstOrDefault();

            return company;
        }


        // update
        public void UpdateCompany(Company company)
        {
            string query =
                "UPDATE Company SET " +
                "Name = @Name, Number = @Number, Street = @Street, City = @City, Postal_Code = @PostalCode, Country = @Country " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            RepoHelper.AddParameters(command, company);

            command.ExecuteNonQuery();
        }


        // delete
        public void DeleteCompany(int id)
        {
            string query =
                "DELETE FROM Company " +
                "WHERE Id = @Id";

            using SqlCommand command = new(query, GetDatabase().GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }


        // methods
        private List<Company> ToModel(SqlDataReader reader)
        {
            List<Company> listCompanies = new();
            while (reader.Read())
            {
                listCompanies.Add(new Company()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Number = reader["Number"].ToString(),
                    Street = reader["Street"].ToString(),
                    City = reader["City"].ToString(),
                    PostalCode = reader["Postal_Code"].ToString(),
                    Country = reader["Country"].ToString(),
                });
            }
            return listCompanies;
        }
    }
}
