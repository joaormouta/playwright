namespace SpecflowPlaywrightPOC.Pages.Bangood
{
    public class BangoodObjects
    {
        public readonly string CategoriesMain = "//a[text()='categories']";
        public readonly string MinPriceInputBox = "//input[@placeholder='min']";
        public readonly string MaxPriceInputBox = "//input[@placeholder='max']";
        public readonly string OkPriceButton = "//div[@class='price-ok']/a";
        public readonly string CloseModalButton = "//a[@class='newuser-close exclick']";

        public static string ButtonWithText(string text)
        {
            return $"//button[text()='{text}']";
        }

        public static string Category(string categoryText)
        {
            return $"//a[@data-string2='{categoryText}']";
        }

        public static string ProductInsideSubcategory(string product, string subCategory)
        {
            return $"//a[contains(text(),'{subCategory}')]/../..//a[contains(text(),'{product}')]";
        }

        public static string ItemListedAtGrid(string item)
        {
            return $"//div[@class='product-list']//a[contains(text(),'{item}')]";
        }
    }
}
