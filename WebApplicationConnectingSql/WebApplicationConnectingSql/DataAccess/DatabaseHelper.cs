using Microsoft.Data.SqlClient;

namespace WebApplicationConnectingSql.DataAccess
{
    public class DatabaseHelper
    {

        private readonly string _connectionString;
        public DatabaseHelper(string connectionString)
        { 
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);

        }


    }
}
