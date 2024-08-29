using Microsoft.AspNetCore.Mvc;
using MvcApiCall.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration; // New using directive.

namespace MvcApiCall.Controllers
{
  public class HomeController : Controller
  {
    private readonly string _apikey; // New property.

    // New Controller.
    public HomeController(IConfiguration configuration)
    {
      _apikey = configuration["NYT"];
    }

    public IActionResult Index()
    {
        List<Article> allArticles = Article.GetArticles(_apikey); // Using _apikey here!
        return View(allArticles);

        /*
            We use dependency injection to access our app's appsettings.json configurations through the IConfiguration service. This service gets injected into our controller in the HomeController constructor as the configuration parameter.

            We don't save the entire configuration object. Instead, we access the "NYT" key to get our API key. We then save this value as a private readonly property called _apikey. We can now use _apikey as needed within our HomeController.

            If you are working with a scaffolded MVC app (using the dotnet new tool), you'll also see a Logger service injected into the HomeController. Ignore that, and update the controller with the new property and the constructor with the new parameter and statement as shown above. We won't learn about the Logger service, but you can optionally read more about it on the docs.
        */
    }
  }
}