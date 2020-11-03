using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataLoader;

namespace dataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            loader.Load("Products.csv");
        }
    }
}
