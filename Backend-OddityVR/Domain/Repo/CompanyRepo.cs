using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class CompanyRepo : AbstractRepo
    {
        // create
        public Company CreateNewCompany(Company company)
        {
            string query =
                "INSERT INTO Company " +
                "(Name, Number, Street, City, Postal_Code, Country) " +
                "OUTPUT INSERTED.Id " + 
                "VALUES (@Name, @Number, @Street, @City, @PostalCode, @Country)";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, company);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            int companyId = (int) command.ExecuteScalar();

            _database.GetDbConnection().Close();
            command.Connection.Close();

            return GetCompanyById(companyId);
        }


        // get all
        public List<Company> GetAllCompanies()
        {
            string query =
                "SELECT * " +
                "FROM Company";

            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Company> companies = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return companies;
        }


        // get id
        public Company GetCompanyById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Company " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            Company company = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return company;
        }


        // update
        public void UpdateCompany(Company company)
        {
            string query =
                "UPDATE Company SET " +
                "Name = @Name, Number = @Number, Street = @Street, City = @City, PostalCode = @Postal_Code, Country = @Country " +
                "WHERE Id = @Id";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, company);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteCompany(int id)
        {
            string query =
                "DELETE FROM Company " +
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


        public SqlCommand AddParameters(SqlCommand command, Company company)
        {
            command.Parameters.AddWithValue("@Name", company.Name);
            command.Parameters.AddWithValue("@Number", company.Number);
            command.Parameters.AddWithValue("@Street", company.Street);
            command.Parameters.AddWithValue("@City", company.City);
            command.Parameters.AddWithValue("@PostalCode", company.PostalCode);
            command.Parameters.AddWithValue("@Country", company.Country);
            if (company.Id != null)
                command.Parameters.AddWithValue("@Id", company.Id);

            return command;
        }
    }
}
