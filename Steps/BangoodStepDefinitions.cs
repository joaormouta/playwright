namespace SpecflowPlaywrightPOC.Steps;

using System.Data;
using System.Threading.Tasks;
using SpecflowPlaywrightPOC.Pages.Bangood;
using SpecflowPlaywrightPOC.Utils;
using SpecflowPlaywrightPOC.Hooks;
using TechTalk.SpecFlow;

[Binding]
public sealed class BangoodStepDefinitions
{
    private readonly BangoodActions bangoodActions;
    private readonly BangoodValidations bangoodValidations;
    public BangoodStepDefinitions(Context context)
    {
        this.bangoodActions = new (context.Page);
        this.bangoodValidations = new (context.Page);
    }

    [Given("hover the category '(.*)'")]
    public async Task IAccessTo(string category)
    {
        await bangoodActions.HoverCategoryText();
        await bangoodActions.SelectCategory(category);
    }

    [Given(@"select the product '(.*)' from the subcategory '(.*)'")]
    public async Task Givenselecttheproductfromthesubcategory(
        string product,
        string subcategory) => await bangoodActions.SelectProductInSubCategory(product, subcategory);

    [When(@"i search an item with the price from '(.*)' to '(.*)'")]
    public async Task Whenisearchanitemwiththepricefromto(string minPrice, string maxPrice) => await this.bangoodActions.SetSearchPrice(minPrice, maxPrice);

    [Then(@"the following items are listed")]
    public async Task Thentheproductisavailable(Table table)
    {
        using DataTable dataTable = TableExtensions.ToDataTable(table);
        foreach (DataRow row in dataTable.Rows)
        {
            await this.bangoodValidations.ItemIsListed(row.ItemArray[0].ToString());
        }
    }
}
