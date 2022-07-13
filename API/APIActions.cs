namespace SpecflowPlaywrightPOC.API;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

public class APIActions : APITouristObjects
{
    private readonly RestClient client = new ("http://restapi.adequateshop.com");
    private readonly string endpoint = "/api/Tourist";
    private readonly SystemTextJsonSerializer serializer = new ();
    private readonly List<int> idTouristCreated;

    public APIActions()
    {
    }

    public async Task<List<int>> AddTouristFromJson(string user)
    {
        var touristJson = File.ReadAllText($"../../../data/{user}.json");
        var tourist = JsonSerializer.Deserialize<APITouristObjects>(touristJson);
        var response = await PostTouristToAPI(client, endpoint, tourist);
        var responseOKAPI = serializer.Deserialize<APITouristResponseOKObjects>(response);
        System.Console.WriteLine(response.Content);
        idTouristCreated.Add(responseOKAPI.Id);
        return idTouristCreated;
    }

    public async Task<List<int>> AddTouristFromJsonList()
    {
        var touristsListJson = File.ReadAllText("../../../data/touristList.json");
        List<APITouristObjects> touristList = JsonSerializer.Deserialize<
            List<APITouristObjects>
        >(touristsListJson);
        foreach (APITouristObjects tourist in touristList)
        {
            var response = await PostTouristToAPI(client, endpoint, tourist);
            var responseOKAPI = serializer.Deserialize<APITouristResponseOKObjects>(response);
            System.Console.WriteLine(response.Content);
            idTouristCreated.Add(responseOKAPI.Id);
        }

        return idTouristCreated;
    }

    public async Task AddTouristsFromTable(Table table)
    {
        var touristList = table.CreateSet<APITouristObjects>();
        foreach (APITouristObjects tourist in touristList)
        {
            var response = await PostTouristToAPI(client, endpoint, tourist);
            var responseOKAPI = serializer.Deserialize<APITouristResponseOKObjects>(response);
            System.Console.WriteLine(response.Content);
            idTouristCreated.Add(responseOKAPI.Id);
        }
    }

    private static async Task<RestResponse> PostTouristToAPI(
        RestClient client,
        string url,
        APITouristObjects tourist)
        {
        var request = new RestRequest(url).AddJsonBody(tourist);
        var response = await client.ExecutePostAsync(request);

        System.Console.WriteLine("xxxxx->" + response.StatusDescription);
        return response;
    }
}
