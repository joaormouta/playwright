namespace SpecflowPlaywrightPOC.Step
{
    using System.Threading.Tasks;
    using SpecflowPlaywrightPOC.Hooks;
    using SpecflowPlaywrightPOC.Pages.Bangood;
    using SpecflowPlaywrightPOC.Pages.Common;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ComonStepDefinitions
    {
        private readonly BangoodActions _bangoodActions;
        private readonly BangoodValidations _bangoodValidations;
        private readonly ComonActions _commonActions = null;

        public ComonStepDefinitions(Context context, ComonActions commonActions)
        {
            _bangoodActions = new BangoodActions(context.Page);
            _bangoodValidations = new BangoodValidations(context.Page);
            _commonActions = commonActions;
        }

        [Given("i access to '(.*)'")]
        public async Task IAccessTo(string site)
        {
            await _commonActions.GoToWebPage(site);
            if (site.Contains("Banggood"))
            {
                await _bangoodActions.AcceptCookies();
                if (await _bangoodValidations.IsNewUserPopupVisible())
                {
                    await _bangoodActions.CloseModal();
                }
            }
        }
    }
}