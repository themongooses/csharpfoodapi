using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroupProject545
{
    class API
    {
        // BEGIN ENDPOINTS //
        public string fridgeEndpoint = @"http://mongoose.theerroris.me/fridge/";
        public string recipeEndpoint = @"http://mongoose.theerroris.me/recipe/";
        public string nutritionEndpoint = @"http://mongoose.theerroris.me/nutrition/";
        public string menuEndpoint = @"http://mongoose.theerroris.me/menu/";
        public string foodEndpoint = @"http://mongoose.theerroris.me/food/";
        // END ENDPOINTS //

        // BEGIN CACHE MEMBERS //
        public List<Recipe> Recipes = new List<Recipe>();
        public List<Ingredient> Ingredients = new List<Ingredient>();
        public List<Nutrition> NutritionalFacts = new List<Nutrition>();
        public List<Menu> Menus = new List<Menu>();
        public List<Food> Fridge = new List<Food>();
        // END CACHE MEMBERS //

        /// <summary>
        /// Makes an API call which refreshes the internal Fridge cache and 
        /// returns the result
        /// </summary>
        /// <returns>A list of Food objects representing foods in the fridge</returns>
        public List<Food> GetFridge()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.fridgeEndpoint);
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

                JArray thing = (JArray)json.GetValue("fridge");
                this.Fridge = thing.ToObject<List<Food>>();

            }
            catch (Exception e)
            {
                throw new Exception(@"Failed to get fridge!");
            }
            return this.Fridge;
        }

        /// <summary>
        /// Makes an API call which refreshes the internal Recipes cache and 
        /// returns the result
        /// </summary>
        /// <returns>A list of Recipe objects representing foods in the fridge</returns>
        public List<Recipe> GetRecipes()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.recipeEndpoint + "all/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

                this.Recipes = ((JArray)json.GetValue("recipes")).ToObject<List<Recipe>>();
            }
            catch (Exception e)
            {
                throw new Exception(@"Failed to get all recipes!");
            }
            return this.Recipes;
        }

        /// <summary>
        /// Makes an API call to get a recipe by its id
        /// </summary>
        /// <param name="id">The numeric integer ID of the recipe to get from the API</param>
        /// <returns>A Recipe object denoting the returned value </returns>
        public Recipe GetRecipe(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.recipeEndpoint + id + "/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<Recipe>(json_string);
            }
            catch (Exception e)
            {
                if (e is APIException)
                {
                    throw e;
                }
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }
        /// <summary>
        /// Makes an API call to get a recipe by its name
        /// </summary>
        /// <param name="name">The name of the recipe to find</param>
        /// <returns>A Recipe object denoting the returned value</returns>
        public Recipe GetRecipe(string name)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.recipeEndpoint + name + "/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<Recipe>(json_string);
            }
            catch (Exception e)
            {
                if (e is APIException)
                {
                    throw e;
                }
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }
        /// <summary>
        /// Given a list of recipe objects, send an API request to update or create the given 
        /// recipe objects. Will update the internal cache with a Union operation
        /// </summary>
        /// <param name="recipes">A List of recipes to update or delete. If a recipe has a null rec_id, it will be added as a new recipe
        /// to the database</param>
        /// <returns>The resolved recipes after they've been saved and updated to the database</returns>
        public List<Recipe> CreateOrUpdateRecipes(List<Recipe> recipes)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.recipeEndpoint);
                request.Method = "POST";
                request.ContentType = "application/json";
                var json_to_send = JsonConvert.SerializeObject(new
                {
                    recipes = recipes.Select(r => new RecipePost
                    {
                        category = r.category,
                        rec_name = r.rec_name,
                        ingredients = r.ingredients.Select(i => i.food_id).ToList(),
                        instructions = r.instructions,
                        rec_id = r.rec_id
                    })
                });

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json_to_send);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                var ret_val = ((JArray) json_response.GetValue("recipes")).ToObject<List<Recipe>>();
                this.Recipes = this.Recipes.Union(ret_val).ToList();
                return ret_val;
            }
            catch (Exception e)
            {
                if (e is APIException)
                {
                    throw e;
                }
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }

        /// <summary>
        /// Given a recipe ID, send an API call to delete the given recipe
        /// </summary>
        /// <param name="id">The ID of the recipe to delte</param>
        /// <returns>Whether it was deleted from the server or not</returns>
        public bool DeleteRecipe(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.recipeEndpoint + id + "/del/");
                request.Method = "DELETE";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<DeleteResponse>(json_string).success;

            }
            catch (Exception e)
            {
                if (e is APIException)
                {
                    throw e;
                }
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }

        }

        public List<Food> CreateOrUpdateFood(List<Food> food)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.foodEndpoint);
                request.Method = "POST";
                request.ContentType = "application/json";
                var json_to_send = JsonConvert.SerializeObject(new
                {
                    food = food.Select(f => new Food
                    {
                        fk_nfact_id = f.fk_nfact_id,
                        food_id = f.food_id,
                        food_name = f.food_name,
                        in_fridge = f.in_fridge,
                        nutrition = f.nutrition
                    })
                });

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json_to_send);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                var ret_val = ((JArray)json_response.GetValue("food")).ToObject<List<Food>>();
                this.Fridge = this.Fridge.Union(ret_val).ToList();
                return ret_val;
            }
            catch (Exception e)
            {
                if (e is APIException)
                {
                    throw e;
                }
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }
    }
}
