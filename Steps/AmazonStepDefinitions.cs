namespace SpecflowPlaywrightPOC.Steps
{
    using System.Threading.Tasks;
    using SpecflowPlaywrightPOC.Hooks;
    using SpecflowPlaywrightPOC.Pages.Amazon;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class AmazonStepDefinitions
    {
        private readonly Amazon _amazon;

        public AmazonStepDefinitions(Context context) => _amazon = new Amazon(context.Page);

        [When("change location to (.*)")]
        public async Task GivenTheFirstNumberIs(string location) => await (await (await _amazon.ChangeLocation()).SelectCountry(location)).ClickDone();

        [Then("the at the banner appears Deliver to (.*)")]
        public async Task ThenTheResultShouldBe(string location) => await _amazon.ValidatePresenceOfLocation(location);
    }
}
