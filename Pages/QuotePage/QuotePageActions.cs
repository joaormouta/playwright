using System.Threading;
using System.Threading.Tasks;
using SpecflowPlaywrightPOC.Hooks;
using SpecflowPlaywrightPOC.Pages.BasePages;
using SpecflowPlaywrightPOC.Resources.Models;

namespace SpecflowPlaywrightPOC.Pages.Quotepage
{
    public partial class QuotePage : BasePage
    {
        public QuotePage(Context page) : base(page)
        {
        }

        public static bool DidThePageLoad()
        {
            return true; // ToDo: What's a good identifier for this?
        }

        public async Task CreateQuote(Quote quote)
        {
            await ClickElement(Menu("New Offer"));
            await AddMainDetailsToQuote(quote);
        }

        private async Task AddMainDetailsToQuote(Quote quote)
        {
            await ClickElement(Tab("Simulation"));
            await SelectItemFromPosMenu(DropDownbox("Dealer"), "senthilkumar");
            await SelectItemFromPosMenu(DropDownbox("Product Type"), quote.PosProductType);
            await SelectItemFromPosMenu(DropDownbox("Vehicle Class"), quote.PosVehicleClass);
            await SelectItemFromPosMenu(DropDownbox("Vehicle state"), quote.PosVehiclestate);
            await SelectItemFromPosMenu(DropDownbox("Make"), quote.PosMake);
            await SelectItemFromPosMenu(DropDownbox("Model"), quote.PosModel);
            await SelectItemFromPosMenu(DropDownbox("Version"), quote.PosVersion);
            await EnterText(TextField("Colour"), quote.PosColour);
            await SelectItemFromPosMenu(AlternativeDropDownbox("Product Variant"), quote.PosProductVariant);
            await ClickElement(ClosePanel("Vehicle Sheet"));
            await SelectItemFromPosMenu(DropDownbox("Period (Months)"), quote.Period);
            await EnterNumber(TextField("Rentals in Advance"), quote.RentalInAdvance);
            await SelectItemFromPosMenu(DropDownbox("Deposit/Initial Payment Method"), quote.PaymentType);
            await ClickElementById(ButtonCalculate);
            await ClickElement(ClosePanel("Results"));
            await ClickElement(Button("Save"));
        }

        public async Task PromoteToProposal(Proposal proposal)
        {
            await AddStateTransistions(proposal);
            await AddEntiteDetailsToProposal(proposal);
            await AddAddressDetailsToProposal(proposal);
            await AddPrivateContactDetailsToProposal(proposal);
            await AddBankDetailsToProposal(proposal);
            await AddAdditionalInfoToProposal(proposal);
            await AddEmploymentHistoryToEntity(proposal);
            await AddBusinessInterestToEntity(proposal);

            await ClickElementById(ButtonEntityConfirm);
            await ClickElementById(MenuProposalSimulation);
            await ClickElementById(ButtonCalculate);
            await ClickElement(ClosePanel("Results"));
            await ClickElementById(ButtonSavePosQuote);
            await ClickElement(ButtonOk);
            await ClickElementById(MenuOtherData);
        }

        public async Task AddStateTransistions(Proposal proposal)
        {
            await SelectItemFromPosMenuByID(InputStateTransition, proposal.StateTransition1);
            await ClickElement(ButtonStateTransition);
            await ClickElement(ButtonOk);
            await SelectItemFromPosMenuByID(InputStateTransition, proposal.StateTransition2);
            await ClickElement(ButtonStateTransition);
            Thread.Sleep(4000);
            await CloseTab();
            await ClickElement(ButtonOk);
            await SelectItemFromPosMenuByID(InputStateTransition, proposal.StateTransition3);
            await ClickElement(ButtonStateTransition);
        }

        public async Task AddEntiteDetailsToProposal(Proposal proposal)
        {
            await ClickElement(Tab("Entities"));
            await ClickElement(AddNewRecord);
            await SelectItemFromPosMenu(DropDownbox("Juridical Type"), proposal.JuridicalType);
            await EnterText(TextField("Name"), proposal.FirstName);
            await EnterText(TextField("Surname"), proposal.SurName);
            await EnterText(TextField("Date of Birth"), proposal.DateOfBirth);
            await EnterText(PostCode("Entity"), proposal.PostCode);
            await EnterText(TextField("First Name"), proposal.GeneralTabFirstName);
            await EnterText(TextField("Last Name"), proposal.GeneralTabLastName);
            await SelectItemFromPosMenu(DropDownbox("Title"), proposal.Title);
            await ClickElement(CheckBox("I hereby declare that the information given in this form is true"));
            await ClickElement(CheckBox("Please confirm that the Customer has read the Privacy Statement"));
            await SelectItemFromPosMenu(DropDownbox("Gender"), proposal.Gender);
            await EnterText(TextField("Date of Birth"), proposal.GeneralTabDateOfBirth);
            ////*[text()='Addresses']/ancestor::table[2]/../following-sibling::div[@class="TabContent"][1]//input[@title="Confirm"]
        }

        public async Task AddAddressDetailsToProposal(Proposal proposal)
        {
            // string buttonInsertAddress = null;
            await ClickElement(AddNewRecord);
            await EnterText(TextField("Street"), proposal.Street);
            await EnterText(PostCode("Address"), proposal.PostCode);
            await EnterText(TextField("Valid from"), proposal.ValidFromDate);
            await SelectItemFromPosMenu(DropDownbox("County"), proposal.Country);
            await ClickElementById(ButtonAddressConfirm);
        }

        public async Task AddPrivateContactDetailsToProposal(Proposal proposal)
        {
            await ClickElement(AddNewPhone);
            await EnterTextById(TextPrivatePhoneNumber, proposal.PrivatePhoneNumber);
            await EnterText(TextField("Email"), proposal.PrivateEmailAddress);
            await ClickElementById(PrivateContactConfirmButton);
        }

        public async Task AddBankDetailsToProposal(Proposal proposal)
        {
            await ClickElementById(MenuBankInformation);
            await EnterText(TextField("Account Number"), proposal.AccountNumber);
            await EnterText(TextField("Sort Code"), proposal.SortCode);
            await EnterTextById(TextTimeWithBankYear, proposal.TimeWithBankYear);
            await EnterTextById(TextTimeWithBankMonth, proposal.TimeWithBankMonth);
            await ClickElementById(ButtonAccountConfirm);
            // await ClickElementById(QuotePageObjects.ButtonOk);
        }

        public async Task AddAdditionalInfoToProposal(Proposal proposal)
        {
            await ClickElementById(MenuAdditionalInfo);
            await SelectItemFromPosMenu(DropDownbox("Marital Status"), proposal.MartialStatus);
            await SelectItemFromPosMenu(DropDownbox("Residence Type"), proposal.ResidenceType);
            await EnterText(TextField("Monthly Rental Payment"), proposal.MonthlyRentalPayment);
        }

        public async Task AddEmploymentHistoryToEntity(Proposal proposal)
        {
            // await ClickElementById(QuotePageObjects.MenuEmploymentHistory);
            await ClickElement(AddNewRecord);
            await SelectItemFromPosMenu(DropDownbox("Occupation"), proposal.Occupation);
            await EnterText(TextField("Occupation Notes"), proposal.OccupationNotes);
            await SelectItemFromPosMenu(DropDownbox("Employment Status"), proposal.EmploymentStatus);
            await EnterText(TextField("Employer Name"), proposal.EmployerName);
            await EnterText(TextField("Years w/ Employer"), proposal.YearWithEmployer);
            await EnterText(EmploymentStartDateMonth, proposal.EmploymentStartDateMonth);
            await EnterText(EmploymentStartDateYear, proposal.EmploymentStartDateYear);
            await EnterText(TextField("Street"), proposal.EmpAddressStreet);
            await EnterTextById(TextHouseNumber, proposal.HouseNumber);
            await EnterText(TextField("Building"), proposal.BuildingName);
            await EnterText(PostCode("Employment"), proposal.EmpAddressPostCode);
            await SelectItemFromPosMenu(DropDownbox("County"), proposal.FieldCounty);
            await EnterText(TextField("Valid from"), proposal.EmpAddressValidFrom);
            await EnterText(TextField("Phone No."), proposal.EmpAddressPhone);
            await ClickElementById(ButtonEmploymentConfirm);
        }

        public async Task AddBusinessInterestToEntity(Proposal proposal)
        {
            await ClickElement(Tab("Business Interests"));
            // await ClickElement(QuotePageObjects.MenuBusinessInterest);
            await SelectItemFromPosMenuByID(InputCompanyCheckBoxAsYes, proposal.BusinessInterestCompanyCheckboxAsYes);
            await ClickElement(AddNewRecord);

            await SelectItemFromPosMenu(DropDownbox("Entity Type"), proposal.EntityType);
            await SelectItemFromPosMenuByID(JuridicalType, proposal.BusinessInterestJuridicalType);
            await EnterText(TextField("Name"), proposal.CompanyName);
            await EnterText(TextField("Company Number"), proposal.TextCompanyNumber);
            await EnterTextById(TextPostCodeOnBusinessInterestTab, proposal.BusinessInterestPostCode);
            await EnterText(TextField("Street"), proposal.BusinessInterestStreet);
            await EnterTextById(TextHouseNumberOnBusinessInterestTab, proposal.BusinessInterestHouseNumber);
            await EnterTextById(TextApartmentOnBusinessInterestTab, proposal.BusinessInterestApartment);
            await EnterText(TextField("Building"), proposal.BusinessInterestBuilding);
            await EnterText(TextField("Locality"), proposal.BusinessInterestLocality);
            await SelectItemFromPosMenu(DropDownbox("County"), proposal.BusinessInterestCounty);
            await EnterText(TextField("Valid from"), proposal.BusinessInterestValidFromDate);
            await ClickElementById(BusinessInterestConfirmButton);
        }

        public async Task<string> GetPosProposalNumber()
        {
            return await _page.Locator(TextBox("Number")).GetAttributeAsync("title");
        }

        public async Task<string> GetProposalState()
        {
            return await _page.Locator(TextBox("State")).GetAttributeAsync("title");
        }

        public async Task<string> GetPosQuoteNumber()
        {
            return await _page.Locator(TextBox("Quotation")).GetAttributeAsync("title");
        }

/*
                  public bool? DidTheQuoteSave() {
                      return IsElementDisplayed(By.Id("ctl00_ctl00_CPHPageBaseContent_CPHMainContent_UCCredOper_IBUpdate"), false);
                  }
                  */
    }
}