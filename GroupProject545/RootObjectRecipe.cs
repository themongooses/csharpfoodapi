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
    class RootObjectRecipe
    {
        [JsonProperty("recipes")]
        public List<Recipe> recipes { get; set; }
    }
}
