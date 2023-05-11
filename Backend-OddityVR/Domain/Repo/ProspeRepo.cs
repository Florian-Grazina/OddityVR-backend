using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class ProspeRepo : AbstractRepo
    {
        // create
        public void CreateNewProspe(Prospe prospe)
        {
            string query =
                "INSERT INTO Prospe " +
                "(Date_Message, Name, Email, Phone, Subject, Message) " +
                "VALUES (@DateMessage, @Name, @Email, @Phone, @Subject, @Message)";

            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, prospe);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Prospe> GetAllProspe()
        {
            string query =
                "SELECT * " +
                "FROM Prospe";

            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Prospe> listProspe = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return listProspe;
        }


        // get id
        public Prospe GetProspeById(int id)
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
            Prospe prospe = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return prospe;
        }


        //// update
        //public void UpdateProspe(Prospe prospe)
        //{
        //    string query =
        //        "UPDATE Prospe SET " +
        //        "DateMessage = @DateMessage, ReadDate = @ReadDate, Name = @Name, Email = @Email, Phone = @Phone, Subject = @Subject, Message = @Message " +
        //        "WHERE Id = @Id";

        //    SqlCommand command = new(query, _database.GetDbConnection());
        //    AddParameters(command, prospe);

        //    // Starting connection with DB and executing
        //    _database.GetDbConnection().Open();

        //    SqlDataReader sqlReader = command.ExecuteReader();

        //    _database.GetDbConnection().Close();
        //    sqlReader.Close();
        //    command.Connection.Close();
        //}


        // delete
        public void DeleteProspe(int id)
        {
            string query =
                "DELETE FROM Prospe " +
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
        private List<Prospe> ToModel(SqlDataReader reader)
        {
            List<Prospe> listCompanies = new();
            while (reader.Read())
            {
                listCompanies.Add(new Prospe()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Subject = reader["Subject"].ToString(),
                    Message = reader["Message"].ToString(),
                    DateMessage = DateTime.Parse(reader["Date_Message"].ToString()),
                    ReadDate = DateTime.TryParse(reader["Read_Date"].ToString(), out DateTime dateResult) ? dateResult : null,
                    UserId = int.TryParse(reader["Id_User"].ToString(), out int intResult) ? intResult : null
                });
            }
            return listCompanies;
        }


        public SqlCommand AddParameters(SqlCommand command, Prospe prospe)
        {
            command.Parameters.AddWithValue("@Name", prospe.Name);
            command.Parameters.AddWithValue("@Email", prospe.Email);
            command.Parameters.AddWithValue("@Phone", prospe.Phone);
            command.Parameters.AddWithValue("@Subject", prospe.Subject);
            command.Parameters.AddWithValue("@Message", prospe.Message);
            command.Parameters.AddWithValue("@DateMessage", prospe.DateMessage);

            //// only needed for updating
            //if (prospe.Id != null)
            //    command.Parameters.AddWithValue("@Id", prospe.Id);

            return command;
        }
    }
}
