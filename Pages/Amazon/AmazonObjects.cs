namespace SpecflowPlaywrightPOC.Pages.Amazon;
public partial class Amazon
{
    public string ChangeDeliverLocation = "//a[@id='nav-global-location-popover-link']";
    public string ButtonDone = "//button[@name='glowDoneButton']";
    public string SelectLocation = "//select[@id='GLUXCountryList']";

    public static string DeliverLocation(string location)
    {
        return $"//span[@id='glow-ingress-line2' and contains(text(),'{location}')]";
    }
}
