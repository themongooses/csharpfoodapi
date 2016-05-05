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
            string endpoint = "http://mongoose.theerroris.me/recipe/1/";
            Console.WriteLine("Making a json request to " + endpoint);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var jsonString = (new StreamReader(httpResponse.GetResponseStream())).ReadToEnd();
            Recipe recipe_json = JsonConvert.DeserializeObject<Recipe>(jsonString);
            Console.WriteLine("Recipe name: " + recipe_json.rec_name);
            Console.WriteLine("Recipe id: " + recipe_json.rec_id);
            Console.WriteLine("Recipe instructions: " + recipe_json.instructions);
            Console.WriteLine("Recipe category: " + recipe_json.category);
            foreach(var ingredient in recipe_json.ingredients)
            {
                Console.WriteLine("Ingredient FK Nutrition fact id: " + ingredient.fk_nfact_id);
                Console.WriteLine("Food id: " + ingredient.food_id);
                Console.WriteLine("Food name: " + ingredient.food_name);
                Console.WriteLine("In fridge: " + ingredient.in_fridge);
            }
            Console.ReadLine();
        }
    }

    class Recipe
    {
        [JsonProperty("category")]
        public string category { get; set; }
        [JsonProperty("ingredients")]
        public List<Ingredient> ingredients { get; set; }
        [JsonProperty("instructions")]
        public string instructions { get; set; }
        [JsonProperty("rec_id")]
        public int rec_id { get; set; }
        [JsonProperty("rec_name")]
        public string rec_name { get; set; }
    }

    class Ingredient
    {
        [JsonProperty("fk_nfact_id")]
        public int fk_nfact_id { get; set; }
        [JsonProperty("food_id")]
        public int food_id { get; set; }
        [JsonProperty("food_name")]
        public string food_name { get; set; }
        [JsonProperty("in_fridge")]
        public bool in_fridge { get; set; }
    }

}
