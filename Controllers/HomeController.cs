using System.Diagnostics;
using DemoMVC.Connections;
using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbConnection _connection;
    
    public HomeController(ILogger<HomeController> logger, MyDbConnection connection)
    {
        _logger = logger;
        _connection = connection;
    }

    public IActionResult Index()
    {
        IndexVm vm = new IndexVm();
        vm.myModel = MyModel.GetOne(_connection);
        vm.myModels = MyModel.GetList(_connection);
        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}