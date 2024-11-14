using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace DemoMVC.Connections;

public class MyDbConnection : IDapperConnnection
{
    private readonly string _connectionString;
    public readonly IMemoryCache _memoryCache;

    public MyDbConnection(IConfiguration configuration, IMemoryCache memoryCache)
    {
        _connectionString = configuration.GetConnectionString("MyDb");
        _memoryCache = memoryCache;
    }

    public IDbConnection CreateConnection()
    {
        try
        {
            return new SqlConnection(_connectionString);
        }
        catch (Exception ex)
        {
            // Handle the exception here
            throw new Exception("Error creating database connection", ex);
        }
    }
}