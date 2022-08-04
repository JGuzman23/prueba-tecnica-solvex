using System.Data.SqlClient;

namespace ATours.Entities.Interfaces
{
    public interface IConnection
    {
        public SqlConnection GetConnection();
    }
}
