using Microsoft.Playwright;

namespace SpecflowPlaywrightPOC.Hooks
{
    public class Context
    {
        public IPage Page { get; set; }

        public IBrowserContext BrowserContext { get; set; }
    }
}
