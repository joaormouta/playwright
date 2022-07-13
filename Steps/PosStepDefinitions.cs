using System.Threading.Tasks;
using NUnit.Framework;
using SpecflowPlaywrightPOC.Pages.Common;
using SpecflowPlaywrightPOC.Pages.LoginPage;
using SpecflowPlaywrightPOC.Pages.Quotepage;
using SpecflowPlaywrightPOC.Pages.Searchpage;
using SpecflowPlaywrightPOC.Resources.Models;
using SpecflowPlaywrightPOC.Utilities.Creators;
using TechTalk.SpecFlow;

namespace SpecflowPlaywrightPOC.Steps
{
    [Binding]
    public class PosStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;
        private readonly ComonActions commonActions;
        private readonly LoginPageActions loginActions;
        private readonly SearchPage searchPage;
        private readonly QuotePage quotePage;
        private Quote quoteDetails;
        private Proposal proposalDetails;
        private Quote currentQuote;
        private Proposal currentProposal;
        public PosStepDefinitions(ScenarioContext scenarioContext, LoginPageActions loginPageActions, QuotePage quotePage, SearchPage searchPage, ComonActions commonActions)
        {
            this.scenarioContext = scenarioContext;
            this.commonActions = commonActions;
            loginActions = loginPageActions;
            this.quotePage = quotePage;
            this.searchPage = searchPage;
        }

        [Given(@"I have all test data for the POS MVP Quotes")]
        // ReSharper disable once InconsistentNaming
        public void GivenIHaveAllTestDataForTheMVPQuotes()
        {
            quoteDetails = QuoteCreator.GetMvpQuote();
            scenarioContext.Add("currentQuote", this.quoteDetails);
        }

        [Given(@"I have all test data for the POS MVP Proposals")]
        public void GivenIHaveAllTestDataForThePOSMVPProposals()
        {
            proposalDetails = QuoteCreator.GetMvpProposal();
            scenarioContext.Add("currentPosProposal", proposalDetails);
        }

        [Given(@"I am on the POS landing page as an external user")]
        public async Task GivenIamonthePOSlandingpageasanexternaluser()
        {
            await commonActions.GoToWebPage("posvwfsuk");
        }

        [When(@"I submit my login details '(.*)' and '(.*)'")]
        public async Task WhenIsubmitmylogindetailslindaandWelcome(string username, string password)
        {
            await loginActions.SubmitCredentials(username, password);
        }

        [When(@"I create the MVP Quote")]
        public async Task GivenIcreatetheMVPQuote()
        {
            currentQuote = (Quote)this.scenarioContext["currentQuote"];
            await quotePage.CreateQuote(this.currentQuote);
        }

        [When(@"I promote the quote to a proposal")]
        public async Task GivenIpromotethequotetoaproposal()
        {
            currentProposal = (Proposal)this.scenarioContext["currentPosProposal"];
            await quotePage.PromoteToProposal(currentProposal);
            var proposalID = await quotePage.GetPosProposalNumber();
            scenarioContext.Add("proposalID", proposalID);
        }

        [When(@"I search for the MVP Pos proposal")]
        public async Task GivenIsearchfortheMVPPosproposal()
        {
            var proposalID = (string)this.scenarioContext["proposalID"];
            // var proposalID = "220003282";
            await searchPage.SearchProposal();
            await searchPage.SearchByNumber(proposalID);
        }

        [Then(@"I should find (.*) Proposal as result")]
        public async Task ThenIshouldfindWORKINGProposalasresult(string expectedResult)
        {
            var proposalState = await quotePage.GetProposalState();
            Assert.AreEqual(proposalState, expectedResult);
        }
    }
}