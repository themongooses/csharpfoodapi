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
    public class Recipe
    {
        public string category { get; set; }
        public Food[] ingredients { get; set; }
        public string instructions { get; set; }
        public int rec_id { get; set; }
        public string rec_name { get; set; }
    }

    public class RecipePost : Recipe
    {
        public List<int> ingredients { get; set; }

        public RecipePost()
        {
            this.ingredients = new List<int>();
        }
    }
}
