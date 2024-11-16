using System.Data;
using Dapper;
using DemoMVC.Connections;
using Microsoft.Extensions.Caching.Memory;

namespace DemoMVC.Models;

public class MyModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    
    // DONE: add Methods GetOneFromMS (key: "mymodel") 與 GetListFromMS (key: "mymodels") 使用 connection._memoryCache 
    public static MyModel GetOne(MyDbConnection connection)
    {
        MyModel one = new MyModel();
        using (var conn = connection.CreateConnection())
        {
            string sql = "select 'id' Id , 'name' Name";
            one = conn.Query<MyModel>(sql, commandType: CommandType.Text).FirstOrDefault();
        }
        return one;
    }
    public static List<MyModel> GetList(MyDbConnection connection)
    {
        List<MyModel> list = new List<MyModel>();
        using (var conn = connection.CreateConnection())
        {
            string sql = "select 'id1' Id , 'name1' Name union select 'id2' Id , 'name2' Name; ";
            list = conn.Query<MyModel>(sql, commandType: CommandType.Text).ToList();
        }
        return list;
    }
    public static MyModel GetOneFromMS(MyDbConnection connection)
    {
        MyModel one = connection._memoryCache.Get<MyModel>("mymodel");
        if (one == null)
        {
            one = GetOne(connection);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));
            connection._memoryCache.Set("mymodel", one, cacheEntryOptions);
        }
        return one;
    }

    public static List<MyModel> GetListFromMS(MyDbConnection connection)
    {
        List<MyModel> list = connection._memoryCache.Get<List<MyModel>>("mymodels");
        if (list == null)
        {
            list = GetList(connection);
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));
            connection._memoryCache.Set("mymodels", list, cacheEntryOptions);
        }
        return list;
    }
    
}