using DemoMVC.Filters;

namespace DemoMVC.Models;

public class TestHomeFilterResultVm
{
    public CustomFilter filter { get; set; }
    public CustomSurvey survey { get; set; }
    

    public TestHomeFilterResultVm()
    {
    }

    //ViewBag.Filter    = surveyModel.GetSurvey(nameof(HomeFilterResult));
    //ViewBag.Survey    = surveyModel.GetSurvey(string.Empty);
    //ViewBag.Model     = surveyModel.GetSurveyModel(dataModel);
    //ViewBag.Metadata  = surveyModel.GetSurveyModel(new { formChoices, currentAcademic, filterResult = fr });
    //ViewBag.ModelList = surveyModel.GetSurveyModel(modelList);   
}

public class CustomFilter
{
    public HomeFilterResult fr { get; set; }

    public CustomFilter(HomeFilterResult input)
    {
        fr = input;
    }
}

public class CustomSurvey
{
    public string surveyrname { get; set; }

    public CustomSurvey(string input)
    {
        surveyrname = input;
    }
}

