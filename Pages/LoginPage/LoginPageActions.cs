using System;
using System.Threading.Tasks;
using SpecflowPlaywrightPOC.Hooks;
using SpecflowPlaywrightPOC.Pages.BasePages;

namespace SpecflowPlaywrightPOC.Pages.LoginPage
{
    public class LoginPageActions : BasePage
    {
        // TODO: Make this configurable
        // public string Url => AppSettings.ApplicationUrl;
        public static string PosIntUrl => string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("INTERNALPOSURL")) ?
            "https://accipiens-i/POSUK/Quotation.aspx" :
            Environment.GetEnvironmentVariable("INTERNALPOS");

        private const int StartIndex = 8;

        public static string GetUrlWithProxy(string url, string userName, string password)
            => $"{url[..8]}{userName}:{password}@{url[StartIndex..]}";

        public static string PosExtUrl()
        {
            return string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("EXTERNALPOSURL")) ?
            "https://pos-int.vwfs.com/POSUK/home.aspx" :
            Environment.GetEnvironmentVariable("EXTERNALPOS");
        }
        // private By PanelPageFooter => By.Id(AutomationIds.PanelPageFooter);

        public LoginPageActions(Context context) : base(context) { }

        public static bool DidThePageLoad() => true; // IsElementDisplayed(PanelPageFooter, false);

        public static bool SignIn => true;

        public async Task SubmitCredentials(string username, string password)
        {
            await EnterText(LoginPageActionsObjects.InputTextBox("Username"), Environment.GetEnvironmentVariable(username));
            await EnterText(LoginPageActionsObjects.InputTextBox("Password"), Environment.GetEnvironmentVariable(password));
      // await EnterText(LoginPageActionsObjects.TextfieldPassword, password);
            await ClickElementById(LoginPageActionsObjects.ButtonLogin);
        }
    }
}