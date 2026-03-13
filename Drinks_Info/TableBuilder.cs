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
            if (tableName == null)
            {
                tableName = "";
            }
            Console.WriteLine("\n\n");
            // TODO not printing the actual item, but printing the namespace... not sure why. It shows DrinksInfo.Models.Category
            var table = new Table()
                .RoundedBorder()
                .AddColumn(tableName);
            foreach (var item in tableData)
            {
                table.AddRow(item.ToString());
            }
            AnsiConsole.Write(table);

        }
    }
}

