using System;
using System.Collections.Generic;
using System.Text;

namespace Drinks_Info
{
    internal class UserInput
    {
        DrinksService drinksService = new();
        internal void GetCategoriesInput()
        {
            drinksService.GetCategories();
        }
    }
}
