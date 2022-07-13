namespace SpecflowPlaywrightPOC.Pages.Bangood
{
    using System.Threading.Tasks;
    using Microsoft.Playwright;
    using SpecflowPlaywrightPOC.Pages.Interface;

    public class BangoodActions : BangoodObjects, ITeste
    {
        private readonly IPage _page;

        public BangoodActions(IPage page)
        {
            _page = page;
        }

        public async Task AcceptCookies()
        {
            await _page.Locator(ButtonWithText("Allow and Close")).ClickAsync();
        }

        public async Task CloseModal()
        {
            await _page.Locator(CloseModalButton).ClickAsync();
        }

        public async Task HoverCategoryText()
        {
            await _page.Locator(CategoriesMain).HoverAsync();
        }

        public async Task SelectCategory(string categoryText)
        {
            await _page.Locator(Category(categoryText)).HoverAsync();
        }

        public async Task SelectProductInSubCategory(string product, string subCategory)
        {
            await _page.Locator(ProductInsideSubcategory(product, subCategory)).ClickAsync();
        }

        public async Task SetSearchPrice(string minPrice, string maxPrice)
        {
            await _page.Locator(MinPriceInputBox).FillAsync(minPrice);
            await _page.Locator(MaxPriceInputBox).FillAsync(maxPrice);
            await _page.Locator(OkPriceButton).ClickAsync();
        }

        public string Xteste()
        {
            return "Bangood";
        }

        public async Task GoToWebPage()
        {
            await _page.GotoAsync("https://www.banggood.com/en/?akmClientCountry=PT");
        }
    }
}
