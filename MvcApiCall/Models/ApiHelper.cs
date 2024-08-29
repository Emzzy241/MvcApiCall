using System.Threading.Tasks;
using RestSharp;

namespace MvcApiCall.Models
{
  class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey)
    {
      RestClient client = new RestClient("https://api.nytimes.com/svc/topstories/v2");
      RestRequest request = new RestRequest($"home.json?api-key={apiKey}", Method.Get);
      RestResponse response = await client.ExecuteAsync(request);
      return response.Content;
    }
  }
}