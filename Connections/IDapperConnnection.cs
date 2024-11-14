using System.Data;

namespace DemoMVC.Connections;

public interface IDapperConnnection
{
    // 連線資料庫
    public IDbConnection CreateConnection();
}