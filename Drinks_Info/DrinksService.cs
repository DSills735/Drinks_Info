using Newtonsoft.Json;
using RestSharp;
using Drinks_Info.Models;
using System.Web;
using System.Reflection;
using drinks_info.Models;

namespace Drinks_Info
{
    internal class DrinksService
    {
        public void GetCategories()
        {

            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"list.php?c=list");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK && response.Result.Content != null)
            {
                string rawResponse = response.Result.Content;

                if (rawResponse != null)
                {
                    var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                    if (serialize != null)
                    {
                        List<Category> returnedList = serialize.CategoriesList!;
                        TableBuilder.ShowTable(returnedList, "Categories");
                    }
                }
            }

        }

        internal void GetDrink(string drink)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK && response.Result.Content != null)
            {
                string rawResponse = response.Result.Content;

                if (rawResponse != null)
                {
                    var serialize = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);

                    if (serialize != null)
                    {
                        List<DrinkDetail> returnedList = serialize.DrinkDetailList!;
                        DrinkDetail drinkDetail = returnedList[0];

                        List<object> prepList = new();

                        string formattedName = "";

                       foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                        {
                            if (prop.Name.Contains("str"))
                            {
                                formattedName = prop.Name.Substring(3);
                            }

                            if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                            {
                                prepList.Add(new
                                {
                                    Key = formattedName,
                                    Value = prop.GetValue(drinkDetail)
                                });
                            }
                        }
                        TableBuilder.ShowDetailsTable(prepList, drinkDetail.strDrink);
                    }
                }
            }
        }

        internal void GetDrinksByCategory(string category)
        {
            var client = new RestClient("http://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK && response.Result.Content != null)
            {
                string rawResponse = response.Result.Content;

                if (rawResponse != null)
                {
                    //TODO handle mis-input error
                    var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                    if (serialize != null)
                    {
                        List<Drink> returnedList = serialize.DrinksList!;
                        TableBuilder.ShowTable(returnedList, "Drinks");
                    }
                }
            }


        }
        
    }
}