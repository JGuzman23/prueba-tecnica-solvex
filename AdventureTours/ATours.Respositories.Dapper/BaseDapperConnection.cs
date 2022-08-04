using ATours.Entities.Interfaces;
using System.Data.SqlClient;

namespace ATours.Respositories.Dapper
{
    public class BaseDapperConnection : IConnection
    {
        public readonly string _connectionString;

        public BaseDapperConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
           return new SqlConnection(_connectionString);
        }
    }
}
