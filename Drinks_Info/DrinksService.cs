using Newtonsoft.Json;
using RestSharp;
using Drinks_Info.Models;

namespace Drinks_Info
{
    internal class DrinksService
    {   
        public void GetCategories()
        {
            //TODO is this calling correct - return code is ok, not sure why the table isnt generating. 
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1");
            var request = new RestRequest("list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content!;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList!;

                TableBuilder.ShowTable(returnedList, "Categories");
            }
        }
    }
}
