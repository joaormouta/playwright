using System.Threading.Tasks;
using Microsoft.Playwright;

namespace SpecflowPlaywrightPOC.Pages.Amazon
{
    public partial class Amazon
    {
        private readonly IPage page;

        public Amazon(IPage page) => this.page = page;
        public async Task<Amazon> ChangeLocation()
        {
            await this.page.ClickAsync(ChangeDeliverLocation);
            return this;
        }

        public async Task<Amazon> SelectCountry(string location)
        {
            await this.page.SelectOptionAsync(SelectLocation, location);
            return this;
        }

        public async Task ClickDone()
        {
            await this.page.ClickAsync(ButtonDone);
        }

        public static string Xteste()
        {
            return "Amazon";
        }

        public async Task GoToWebPage()
        {
            await this.page.GotoAsync("http://www.cnn.com");
        }
    }
}