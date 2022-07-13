namespace SpecflowPlaywrightPOC.Pages.Bangood
{
    using System.Threading.Tasks;
    using Microsoft.Playwright;

    public class BangoodValidations : BangoodObjects
    {
        private readonly IPage _page;

        public BangoodValidations(IPage page)
        {
            _page = page;
        }

        public async Task ItemIsListed(string item)
        {
            await _page.Locator(ItemListedAtGrid(item)).WaitForAsync();
        }

        public async Task<bool> IsNewUserPopupVisible()
        {
            System.Console.WriteLine(_page.Locator(CloseModalButton).IsVisibleAsync());
            return await _page.Locator(CloseModalButton).IsVisibleAsync();
        }
    }
}
