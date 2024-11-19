using System.Diagnostics;
using DemoMVC.Connections;
using DemoMVC.Filters;
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
    public async Task<IActionResult> IndexFilter(HomeFilterResult fr) {
        TestHomeFilterResultVm vm = new TestHomeFilterResultVm();
        // HomeFilterResult fr = new HomeFilterResult();
        // fr.keyword = "key";
        // fr.ordby = "asc";
        // fr.yr = 113;
        // fr.sem = 1;
        vm.filter = new CustomFilter(fr);
        vm.survey = new CustomSurvey("sharon");
        // Console.WriteLine($"{ResearchProjectWeb.Models.PO.SharonAdd.linecount++}: HomeController-Index");
        // var dataModel   = new { };
        // var surveyModel = new SurveyJS(webRootPath);
        // var formChoices = await dataService.GetModelOptionsAsync();
        // var modelList   = await dataService.GetModelsAsync(this.userId, fr.proj_status, fr.startBy, fr.startByValue, fr.proj_type);
        //
        // ViewBag.Filter    = surveyModel.GetSurvey(nameof(HomeFilterResult));
        // ViewBag.Survey    = surveyModel.GetSurvey(string.Empty);
        // ViewBag.Model     = surveyModel.GetSurveyModel(dataModel);
        // ViewBag.Metadata  = surveyModel.GetSurveyModel(new { formChoices, currentAcademic, filterResult = fr });
        // ViewBag.ModelList = surveyModel.GetSurveyModel(modelList);            
 
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