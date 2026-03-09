using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace Drinks_Info
{
    internal class TableBuilder
    {

        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) 
            where T : class
        {
            Console.Clear();
            if(tableName == null)
            {
                tableName = "";

                Console.WriteLine("\n\n");

                //TODO need to use spectre below to build the table below.. 

            }
        }
    }
}
