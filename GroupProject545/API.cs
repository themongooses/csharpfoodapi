﻿using System;
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
        public List<Food> Ingredients = new List<Food>();
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
                throw new APIException(@"Failed to get all recipes!");
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

                var ret_val = ((JArray)json_response.GetValue("recipes")).ToObject<List<Recipe>>();
                this.Recipes = this.Recipes.Union(ret_val).ToList();
                return ret_val;
            }
            catch (Exception e)
            {
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
                this.Ingredients = this.Ingredients.Union(ret_val).ToList();
                return ret_val;
            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }

        public bool DeleteFood(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.foodEndpoint + id + "/del/");
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
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }

        }

        public Food GetFood(string name)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.foodEndpoint + name + "/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<Food>(json_string);
            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }

        public Food GetFood(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.foodEndpoint + id + "/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<Food>(json_string);
            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }

        /// <summary>
        /// Queries the server and updates the internal cache member with Food objects
        /// representing all Food objects currently on the server
        /// </summary>
        /// 
        /// <returns>A List of Food objects taht was returned from the server</returns>

        public List<Food> GetFoods()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.foodEndpoint + "all/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

                this.Ingredients = ((JArray)json.GetValue("food")).ToObject<List<Food>>();
            }
            catch (Exception e)
            {
                throw new APIException(@"Failed to get all foods!");
            }
            return this.Ingredients;
        }

        /// <summary>
        /// Sends a list of nutrition objects to be created or updated to the server. Will
        /// update the internal cache to hold new and updated nutrition objects
        /// </summary>
        /// <param name="nutrition">A list of Nutrition objects to be updated or created. If an nfact_id is 
        /// present on a Nutrition object, it will be updated on the server. Otherwise it will take the
        /// values and create a new Nutrition record.</param>
        /// <returns>A list of Nutrition objects that were updated or created by the server</returns>
        public List<Nutrition> CreateOrUpdateNutrition(List<Nutrition> nutrition)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.nutritionEndpoint);
                request.Method = "POST";
                request.ContentType = "application/json";
                var json_to_send = JsonConvert.SerializeObject(new
                {
                    nutrition = nutrition.Select(n => new Nutrition
                    {
                        nfact_id = n.nfact_id,
                        calories = n.calories,
                        sodium = n.sodium,
                        fat = n.fat,
                        food_group = n.food_group,
                        amount = n.amount,
                        protein = n.protein,
                        sugar = n.sugar
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

                var ret_val = ((JArray)json_response.GetValue("nutritional_facts")).ToObject<List<Nutrition>>();
                this.NutritionalFacts = this.NutritionalFacts.Union(ret_val).ToList();
                return ret_val;
            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }
        }
        /// <summary>
        /// Delete a nutrition record from the server and update the internal cache
        /// </summary>
        /// <param name="id">The nfact_id of the Nutrition object to delete</param>
        /// <returns></returns>
        public bool DeleteNutrition(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.nutritionEndpoint + id + "/del/");
                request.Method = "DELETE";

                var response = (HttpWebResponse)request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }
                // Update the internal cache by selecting all cache members that don't have the 
                // id. This saves an API call
                this.NutritionalFacts = this.NutritionalFacts.Where(n => n.nfact_id != id).ToList();
                return JsonConvert.DeserializeObject<DeleteResponse>(json_string).success;

            }
            catch (Exception e)
            {
                if (e is WebException)
                {
                    throw new APIException("@Server responded with: " + e.Message);
                }
                throw e;
            }

        }
        
        /// <summary>
        /// Query the API for a Nutritional Fact based on its numeric ID
        /// </summary>
        /// <param name="id">The nfact_id of the Nutritional Fact to query for</param>
        /// <returns>A Nutrition object if the server found one, null if not</returns>
        public Nutrition GetNutrition(int id)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.nutritionEndpoint + id + "/");
                request.Method = "GET";

                var response = (HttpWebResponse) request.GetResponse();
                var json_string = (new StreamReader(response.GetResponseStream())).ReadToEnd();
                var json_response = JObject.Parse(json_string);
                var error = json_response.Property("error");
                if (error != null)
                {
                    throw new APIException(@"Server returned with error: " + error);
                }

                return JsonConvert.DeserializeObject<Nutrition>(json_string);
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    if (((HttpWebResponse) e.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        return null;
                    }
                }
                throw new APIException("@Server responded with: " + e.Message);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Queries the API to update the cache with all nutritional facts on the server
        /// </summary>
        /// <returns>The result of querying the server for all nutritional facts</returns>
        public List<Nutrition> GetNutritions()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.nutritionEndpoint + "all/");
                request.Method = "GET";

                var response = (HttpWebResponse)request.GetResponse();
                var json = JObject.Parse((new StreamReader(response.GetResponseStream())).ReadToEnd());

                this.NutritionalFacts = ((JArray)json.GetValue("nutritional_facts")).ToObject<List<Nutrition>>();
            }
            catch (Exception e)
            {
                throw new Exception(@"Failed to get all nutritional facts!");
            }
            return this.NutritionalFacts;
        }
    }
}
