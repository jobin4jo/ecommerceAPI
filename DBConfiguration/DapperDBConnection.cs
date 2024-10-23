using Microsoft.Data.SqlClient;
using System.Data;
namespace ecommerceAPI.DBConfiguration;


public class DapperDbConnection
{
    public readonly string _connectionString;
    public DapperDbConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
