namespace SpecflowPlaywrightPOC.Pages.Demo;
public class DemoQABrowserWindowsObjects
{
    public static string Button(string textButton)
    {
        return $"//button[text()='{textButton}']";
    }
}
