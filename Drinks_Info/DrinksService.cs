using Newtonsoft.Json;
using RestSharp;
using Drinks_Info.Models;

namespace Drinks_Info
{
    internal class DrinksService
    {
        public void GetCategories()
        {
            var client = new RestClient("www.thecocktaildb.com/api/json/v1/1");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content!;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList!;

                //TODO call the table builder here. 
            }
        }
    }
}
