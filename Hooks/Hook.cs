using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowPlaywrightPOC.Drivers;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace SpecflowPlaywrightPOC.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly Context _context;

        public Hooks(Context context) => _context = context;

        [BeforeScenario]
        public async Task Initialize()
        {
             var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE");
             _context.BrowserContext = await Driver.CreatePlaywright(
                browserType,
                new BrowserTypeLaunchOptions { Headless = false });
             _context.Page = await _context.BrowserContext.NewPageAsync();
        }

        [AfterScenario, Scope(Tag = "web")]
        public async Task AfterScenario()
        {
            await _context.Page.CloseAsync();
        }
    }
}
