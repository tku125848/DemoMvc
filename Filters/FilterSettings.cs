namespace DemoMVC.Filters;

public class FilterSettings
{
    public static string GetWebRootPath(IConfiguration configuration)
    {
        
        return configuration["WebRootPath"];
    }

    public static string GetCurrentAcademic()
    {
        return "1131"; 
    }
}