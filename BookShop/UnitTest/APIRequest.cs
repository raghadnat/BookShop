using Microsoft.IdentityModel.Tokens;
using RestSharp;

namespace BookShop.UnitTest
{
    public class APIRequest
    {
        string baseUrl = "https://localhost:7284/api/book/GetAll";

        public RestResponse GetApiRequest()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        public RestResponse PostApiRequest()
        {

            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest();
            RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        public RestResponse PutApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Put);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
        public static ApiEntities BuildBodyRequest(int? id =null)
        {
            return new ApiEntities
            {
                Id =id?? 0,
                Title = "Test Book",
                price =20,
                Author = "uem num gosta di mim que vai caçá sua turmis!",
                Genre = "test",
                PublicationYear = 2023
            };
        }
        public RestResponse DeleteFakeApiRequest(int id)
        {
            RestClient client = new RestClient(baseUrl);
            var body = BuildBodyRequest(id);
            RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Delete);
            restRequest.AddBody(body, ContentType.Json);

            RestResponse restResponse = client.Execute(restRequest);

            return restResponse;
        }
      
    }
}
