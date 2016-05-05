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
            List<Recipe> recipe_json = JsonConvert.DeserializeObject<List<Recipe>>(jsonString); //error here
        }
    }

    class Recipe
    {
        [JsonProperty("category")]
        public string category { get; set; }
        [JsonProperty("ingredients")]
        public List<string> ingredients { get; set; }
        [JsonProperty("instructions")]
        public string instructions { get; set; }
        [JsonProperty("rec_id")]
        public int rec_id { get; set; }
        [JsonProperty("rec_name")]
        public string rec_name { get; set; }
    }
}
