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
    class Recipe
    {
        /// <summary>
        /// This class defines the JSON properties that are being retrieved for a recipe.
        /// </summary>
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

        public RootObjectRecipe GetAllRecipes()
        {
            string endpoint = "http://mongoose.theerroris.me/recipe/all/";
            Console.WriteLine("Making a json request to " + endpoint);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var jsonString = (new StreamReader(httpResponse.GetResponseStream())).ReadToEnd();
            RootObjectRecipe recipe_json = JsonConvert.DeserializeObject<RootObjectRecipe>(jsonString);
            foreach (var recipes in recipe_json.recipes)
            {
                Console.WriteLine("Recipe name: " + recipes.rec_name);
                Console.WriteLine("Recipe id: " + recipes.rec_id);
                Console.WriteLine("Recipe instructions: " + recipes.instructions);
                Console.WriteLine("Recipe category: " + recipes.category);
                foreach (var ingredient in recipes.ingredients)
                {
                    Console.WriteLine("Ingredient FK Nutrition fact id: " + ingredient.fk_nfact_id);
                    Console.WriteLine("Food id: " + ingredient.food_id);
                    Console.WriteLine("Food name: " + ingredient.food_name);
                    Console.WriteLine("In fridge: " + ingredient.in_fridge);
                }
            }
            Console.ReadLine();
            return recipe_json;
        }

        public Recipe GetARecipe(int recipe_id)
        {
            string endpoint = "http://mongoose.theerroris.me/recipe/" + recipe_id + "/";
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
            foreach (var ingredient in recipe_json.ingredients)
            {
                Console.WriteLine("Ingredient FK Nutrition fact id: " + ingredient.fk_nfact_id);
                Console.WriteLine("Food id: " + ingredient.food_id);
                Console.WriteLine("Food name: " + ingredient.food_name);
                Console.WriteLine("In fridge: " + ingredient.in_fridge);
            }
            Console.ReadLine();
            return recipe_json;
        }
    }
}
