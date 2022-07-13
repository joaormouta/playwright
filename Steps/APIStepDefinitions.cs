namespace SpecflowPlaywrightPOC.Steps
{
    using System.Threading.Tasks;
    using SpecflowPlaywrightPOC.API;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class APIStepDefinitions
    {
        private readonly APIValidations _apiValidations;
        private readonly APIActions _apiActions;
        private readonly ScenarioContext _scenarioContext;

        public APIStepDefinitions()
        {
            _apiValidations = new APIValidations();
            _apiActions = new APIActions();
        }

        [Given(@"A list of Tourists is available")]
        public async Task GivenAlistofbooksareavailable() => await _apiValidations.SiteIsOk();

        [When(@"I add the Tourist '(.*)' to the tourist list")]
        public async Task WhenIaddtheTouristtothetouristlist(string user) => await _apiActions.AddTouristFromJson(user);

        [When(@"I add the Tourist table to the tourist list")]
        public async Task WhenIaddtheTouristtabletothetouristlist(Table table) => await _apiActions.AddTouristsFromTable(table);

        [Then(@"I can see their presence at the tourist list")]
        public void Thenicanseeitspresenceatthetouristlist() => _scenarioContext.Pending();

        [Given(@"a table row hash step")]
        public void Givenatablerowhashstep() => _scenarioContext.Pending();
    }
}
