using Newtonsoft.Json;

namespace Drinks_Info.Models
{
    //TODO I added the null modifier onto these. Not sure if that is acceptable or not. 
    //figure it out. 
    public class Category
    {
        public string? StrCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]
        public List<Category>? CategoriesList { get; set; }
    }
}
