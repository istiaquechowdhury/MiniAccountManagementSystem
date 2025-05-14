using Microsoft.Data.SqlClient;
using System.Data;


namespace MiniAccountManagementSystem.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable ExecuteStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable resultTable = new DataTable();
            adapter.Fill(resultTable);
            return resultTable;
        }

        public void ExecuteNonQuery(string storedProcedureName, SqlParameter[] parameters = null)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
