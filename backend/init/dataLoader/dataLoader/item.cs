using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataLoader
{
    public class Item
    {
        public string UPC;
        public string ingredients;

        public Item(string upc, string ingred)
        {
            UPC = upc;
            ingredients = ingred;
        }
    }
}
