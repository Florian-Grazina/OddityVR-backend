using Backend_OddityVR.Model;
using System.Data.SqlClient;

namespace Backend_OddityVR.Domain.Repo
{
    public class BatchRepo : AbstractRepo
    {
        // create
        public void CreateNewBatch(Batch batch)
        {
            string query =
                "INSERT INTO Batch (Creation_Date, Id_User) " +
                "VALUES (@CreationDate, @UserId)";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, batch);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // get all
        public List<Batch> GetAllBatches()
        {
            string query =
                "SELECT * " +
                "FROM Batch";
            SqlCommand command = new(query, _database.GetDbConnection());

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            List<Batch> batchs = ToModel(sqlReader);

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return batchs;
        }


        // get id
        public Batch GetBatchById(int id)
        {
            string query =
                "SELECT * " +
                "FROM Batch " +
                "WHERE ID = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            command.Parameters.AddWithValue("@Id", id);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();
            Batch Batch = ToModel(sqlReader).First();

            _database.GetDbConnection().Close();

            sqlReader.Close();
            command.Connection.Close();

            return Batch;
        }


        // update
        public void UpdateBatch(Batch Batch)
        {
            string query =
                "UPDATE Batch " +
                "SET Creation_Date = @CreationDate, Id_user = @UserId " +
                "WHERE Id = @Id";
            SqlCommand command = new(query, _database.GetDbConnection());
            AddParameters(command, Batch);

            // Starting connection with DB and executing
            _database.GetDbConnection().Open();

            SqlDataReader sqlReader = command.ExecuteReader();

            _database.GetDbConnection().Close();
            sqlReader.Close();
            command.Connection.Close();
        }


        // delete
        public void DeleteBatch(int id)
        {
            string query =
                "DELETE FROM Batch " +
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
        public List<Batch> ToModel(SqlDataReader reader)
        {
            List<Batch> listBatchs = new();
            while (reader.Read())
            {
                listBatchs.Add(new Batch()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    CreationDate = DateTime.Parse(reader["Creation_Date"].ToString()),
                    UserId = int.Parse(reader["Id_User"].ToString())
                });
            }
            return listBatchs;
        }

        public SqlCommand AddParameters(SqlCommand command, Batch batch)
        {
            command.Parameters.AddWithValue("@CreationDate", batch.CreationDate);
            command.Parameters.AddWithValue("@UserId", batch.UserId);
            if (batch.Id != null)
                command.Parameters.AddWithValue("@Id", batch.Id);

            return command;
        }
    }
}
