namespace SpecflowPlaywrightPOC.API
{
    using System.Threading.Tasks;
    using RestSharp;

    public class APIValidations
    {
        private readonly RestClient client = new ("http://restapi.adequateshop.com");

        public APIValidations() { }

        public async Task SiteIsOk()
        {
            var request = new RestRequest("/api/Feed/GetNewsFeed");
            var response = await this.client.ExecuteGetAsync(request);
            System.Console.WriteLine(response.IsSuccessful);
        }
    }
}