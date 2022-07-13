namespace SpecflowPlaywrightPOC.Drivers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    using SpecflowPlaywrightPOC.Models;

    public class Driver
    {
        public static async Task<IBrowserContext> CreatePlaywright(
            string inBrowser,
            BrowserTypeLaunchOptions inLaunchOptions)
        {
            var playwright = await Playwright.CreateAsync();
            BrowserItem browserItem = (BrowserItem)Enum.Parse(typeof(BrowserItem), inBrowser);
            IBrowser browser = null;
            if (browserItem == BrowserItem.Chromium)
            {
                browser = await playwright.Chromium.LaunchAsync(inLaunchOptions);
            }

            if (browserItem == BrowserItem.Firefox)
            {
                browser = await playwright.Firefox.LaunchAsync(inLaunchOptions);
            }

            if (browserItem == BrowserItem.WebKit)
            {
                browser = await playwright.Webkit.LaunchAsync(inLaunchOptions);
            }

            return await browser.NewContextAsync(new BrowserNewContextOptions { ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 } });
        }
    }
}
