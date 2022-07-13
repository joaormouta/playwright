namespace SpecflowPlaywrightPOC.Utilities.Creators
{
    using SpecflowPlaywrightPOC.Resources.Enums;
    using SpecflowPlaywrightPOC.Resources.Models;
    using SpecflowPlaywrightPOC.Utilities.Helpers;

    public class QuoteCreator
    {
        private static Quotes currentQuotes;

        private static Proposals currentProposals;

        public QuoteCreator()
        {
        }

        public static Quote GetMvpQuote()
        {
            currentQuotes = TestDataHelper.LoadFromFile<Quotes>(
                "UK",
                "",
                "Skoda",
                "Quotes2");
            return currentQuotes.ListOfQuotes[(int)LoginAs.Valid]; // Needs looking at
        }

        public static Proposal GetMvpProposal()
        {
            currentProposals = TestDataHelper.LoadFromFile<Proposals>(
               "UK",
               "",
               "VW",
               "Proposals");
            return currentProposals.ListOfProposals[(int)LoginAs.Valid];
        }
    }
}
