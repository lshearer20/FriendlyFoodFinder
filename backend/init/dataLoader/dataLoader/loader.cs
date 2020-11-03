using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dataLoader
{
    public static class loader
    {
        public static void Load(string path)
        {
            var lines = File.ReadLines(path);
            List<Item> items = new List<Item>();
            foreach (var line in lines)
            {
                string[] words = line.Split(new string[] {"\",\""}, StringSplitOptions.None);
                items.Add(new Item(words[3], words[7].Substring(0, words[7].Length - 1)));
            }

            List<List<Item>> list = new List<List<Item>>();
            for (int i = 0; i <= items.Count / 998; i++)
            {
                if (i == items.Count / 999)
                {
                    list.Add(items.GetRange(i * 999, items.Count % 999));
                }
                else
                {
                    list.Add(items.GetRange(i * 999, 999));
                }
            }

            int j = 0;
            SqlConnection connection = new SqlConnection("Server=tcp:friendly-food-finder.database.windows.net,1433;Initial Catalog=friendly-food-finder;Persist Security Info=False;User ID=Admin123;Password=Admin$123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connection.Open();
            foreach (var subList in list)
            {
                Console.Out.WriteLine(j++);
                // TODO add connection string
                String formattedValueString = "INSERT INTO Nutrition(upc, ingredients) values ";
                foreach (var val in subList)
                {
                    formattedValueString += $"('{val.UPC}', '{val.ingredients.Replace("'", "''")}'), ";
                }
                formattedValueString = formattedValueString.Replace("\"", "");
                formattedValueString = formattedValueString.Substring(0, formattedValueString.Length - 2);
                
                SqlCommand command = new SqlCommand(formattedValueString, connection);
                command.ExecuteNonQuery();
            }



        }
    }
}
