using System.Data;
using Dapper;
using DemoMVC.Connections;

namespace DemoMVC.Models;

public class MyModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    
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
}