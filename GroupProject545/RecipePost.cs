//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//
//namespace GroupProject545
//{
//    class RecipePost
//    {
//        [JsonProperty("category")]
//        public string category { get; set; }
//        [JsonProperty("ingredients")]
//        public List<IngredientPost> ingredients_post = new List<IngredientPost>();
//        [JsonProperty("instructions")]
//        public string instructions { get; set; }
//        [JsonProperty("rec_id")]
//        public int rec_id { get; set; }
//        [JsonProperty("rec_name")]
//        public string rec_name { get; set; }
//        public void CreateRecipe()
//        {
//            var obj_to_serialize = new
//            {
//                recipes
//            }
//            string json = JsonConvert.SerializeObject(new
//            {
//                
//            });
//            string endpoint = "http://mongoose.theerroris.me/recipe/";
//            var httpWebRequest = (HttpWebRequest)WebRequest.Create(endpoint);
//            httpWebRequest.ContentType = "application/json";
//            httpWebRequest.Method = "POST";
//
//            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
//            {
//                streamWriter.Write(json);
//            }
//
//            try
//            {
//                var httpResponse = (HttpWebResponse) httpWebRequest.GetResponse();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            
////            var jsonString = (new StreamReader(httpResponse.GetResponseStream())).ReadToEnd();
////            Console.WriteLine(jsonString);
//            Console.ReadLine();
//        }
//    }
//}
