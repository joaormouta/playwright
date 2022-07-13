namespace SpecflowPlaywrightPOC.Steps
{
    using System.Threading;
    using System.Threading.Tasks;
    using SpecflowPlaywrightPOC.Hooks;
    using SpecflowPlaywrightPOC.Pages.Demo;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class DemoQADefinitions
    {
        private readonly DemoQABrowserWindowsActions _demoQABrowserWindowsActions;
        private readonly Context _context = null;

        public DemoQADefinitions(Context context)
        {
            _context = context;
            _demoQABrowserWindowsActions = new (context.Page);
        }

        [When(@"open a '(.*)'")]
        public async Task Whenopena(string args1)
        {
            var newPage = await _context.BrowserContext.RunAndWaitForPageAsync(
                async () =>
                {
                    await _demoQABrowserWindowsActions.ClickButton(args1);
                });
            await newPage.WaitForLoadStateAsync();
        }

        [Then(@"i see the following message '(.*)'")]
        public async Task Theniseethefollowingmessage(string args1)
        {
            await _context.BrowserContext.Pages[1].Locator("//h1").TextContentAsync();
            await _context.BrowserContext.Pages[0].Locator("//span[text()='Text Box']").TextContentAsync();
            System.Console.WriteLine(args1);
            Thread.Sleep(5000);
            await _context.BrowserContext.Pages[0].BringToFrontAsync();
            Thread.Sleep(5000);
            await _context.BrowserContext.Pages[1].CloseAsync();
        }
    }
}
