namespace SpecflowPlaywrightPOC.Pages.Common;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using SpecflowPlaywrightPOC.Hooks;

public class ComonActions
{
    private readonly IPage page;

    public ComonActions(Context context)
    {
        this.page = context.Page;
    }

    public async Task GoToWebPage(string siteValue)
    {
        var sitesData = File.ReadAllText("../../../data/site.json");
        var site = JObject.Parse(sitesData)[siteValue].ToString();
        await this.page.GotoAsync(site);
    }

    public async Task LoadPage(string siteURL)
    {
        await this.page.GotoAsync(siteURL);
    }
}