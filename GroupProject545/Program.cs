using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GroupProject545
{
    class Program
    {
        static void Main(string[] args)
        { 
            API api = new API();
            Console.WriteLine($"The API says: {api.DeleteRecipe(4)}");
            Console.ReadLine();
        }
    }
}
