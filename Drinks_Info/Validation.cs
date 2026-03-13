
namespace Drinks_Info
{
    internal class Validation
    {
        internal static bool isStringValid(string category)
        {
            if (category == null)
            {
                return false;
            }
            else if (category.Length == 0)
            {
                return false;
            }
            foreach (char c in category)
            {
                if (!Char.IsLetter(c) && c != '/' && c != ' ')
                {
                    return false;
                }

            }
            return true;
        }
    }
}
