namespace SpecflowPlaywrightPOC.Pages.Searchpage
{
    public partial class SearchPage
    {
        public const string InputKind = "CustomSelectContainer_ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCCredOperSearch_CPHMain_FVCredOperSearch_DDLCredOperStep";
        public const string ButtonSearch = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCCredOperSearch_IBSearch";
        public const string MenuOtherData = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCCredOper_CPHMain_MProposalDetailsn2";
        public const string MenuQuoteOtherData = "ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCCredOper_CPHMain_MQuotationDetails_ctl01_lblMenuItem";
        public const string PosQuotationId = "LTBCredOperNumber";
        public const string PosProposalId = "LTBCredOperNumber";
        public const string SearchNumber = "//span[text()='Kind / Number']/../div[3]/input";
        public static string TextBox(string label) => $"//span[text()='{label}']/following-sibling::span[1]";
        public static string Tab(string label) => $"//span[text()='{label}']/ancestor::a";
        public static string Button(string label) => $"//div[@title='{label}']/input";
        public static string Menu(string label) => $"//div[@class='MainNavigation']//a[text()='{label}']";
        public static string DropDownbox(string label) => $"//span[text()='{label}']/following-sibling::div/div";
    }
}