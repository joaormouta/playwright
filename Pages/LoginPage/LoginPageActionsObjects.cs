namespace SpecflowPlaywrightPOC.Pages.LoginPage
{
    internal class LoginPageActionsObjects
    {
        public const string TabNewOffer = "ctl00_ctl00_CPHPageBaseContent_CPHPageHeaderContent_CPHPageHeaderMainMenu_MMainNavigationn2";
   // public const string TextfieldUsername = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCBOXLogin_TBUsername";
   // public const string TextfieldPassword = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCBOXLogin_TBPassword";
        public static string InputTextBox(string label) => $"//label[contains(text(),'{label}:')]/following-sibling::input";
        public const string ButtonLogin = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCBOXLogin_BLogin";
    }
}