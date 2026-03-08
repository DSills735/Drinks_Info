using RestSharp;
using System.Net.Http.Headers;

namespace Drinks_Info
{
    internal class DrinksService
    {
        public void GetCategories()
        {
            var client = new RestClient("www.thecocktaildb.com/api/json/v1/1");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);


        }
    }
}
