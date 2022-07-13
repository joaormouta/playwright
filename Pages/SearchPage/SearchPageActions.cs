using System.Threading;
using System.Threading.Tasks;
using SpecflowPlaywrightPOC.Hooks;
using SpecflowPlaywrightPOC.Pages.BasePages;

namespace SpecflowPlaywrightPOC.Pages.Searchpage
{
    public partial class SearchPage : BasePage
    {
        public SearchPage(Context page) : base(page)
        {
        }

        public static bool DidThePageLoad()
        {
            return true; // ToDo: What's a good identifier for this?
        }

        public async Task SearchByNumber(string number)
        {
            await EnterText(SearchNumber, number);
            await ClickElement(Button("Search"));
            await ClickElement(Tab("Other Data"));
        }

        public async Task SearchByCreatedId(string createdID)
        {
            await EnterText(SearchNumber, createdID);
            await ClickElement(ButtonSearch);
        }

        public async Task SearchProposal()
        {
            await ClickElement(Menu("Search"));
            await SelectItemFromPosMenu(DropDownbox("Kind / Number"), "Proposal");
        }

        public async Task SearchQuote()
        {
            await ClickElement(Menu("Search"));
            await SelectItemFromPosMenu(DropDownbox("Kind / Number"), "Quotation");
        }

        public async Task<string> QuoteNumber()
        {
            await ClickElement(MenuQuoteOtherData);
            return await _page.Locator($"id={PosQuotationId}").GetAttributeAsync("title");
        }

        public async Task<string> ProposalNumber()
        {
            await ClickElement(MenuOtherData);
            return await _page.Locator($"id={PosProposalId}").GetAttributeAsync("title");
        }
    }
}