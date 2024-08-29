using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MvcApiCall.Models
{
  public class Article
  {
    public string Section { get; set; }
    public string Title { get; set; }
    public string Abstract { get; set; }
    public string Url { get; set; }
    public string Byline { get; set; }
    public string Item_Type { get; set; }

    public static List<Article> GetArticles(string apiKey)
    {
      Task<string> apiCallTask = ApiHelper.ApiCall(apiKey);
      string result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      List<Article> articleList = JsonConvert.DeserializeObject<List<Article>>(jsonResponse["results"].ToString());

      return articleList;
    }
  }
}