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
