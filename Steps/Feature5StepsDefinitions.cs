namespace specflowPlaywrightPOC.Steps;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SpecflowPlaywrightPOC.Hooks;
using SpecflowPlaywrightPOC.Pages.Bangood;
using SpecflowPlaywrightPOC.Pages.Interface;
using TechTalk.SpecFlow;

[Binding]
public class Feature5StepsDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly Context _context;

    public Feature5StepsDefinitions(
        ScenarioContext scenarioContext,
        Context context)
        {
        this._context = context;
        this._scenarioContext = scenarioContext;
    }

    [Given(@"i access to webpage")]
    public async Task Giveniaccesstowebpage()
    {
        List<ITeste> aa = new ()
        {
        // aa.Add(new Amazon(_context.Page));
        new BangoodActions(this._context.Page),
        };
        for (int i = 0; i < aa.Count; i++)
        {
            System.Console.WriteLine(aa[i].Xteste());
            await aa[i].GoToWebPage();
            Thread.Sleep(5000);
        }
    }

    [When(@"i play around")]
    public void Wheniplayaround()
    {
        _scenarioContext.Pending();
    }

    [Then(@"i an success")]
    public void Theniansuccess()
    {
        _scenarioContext.Pending();
    }
}