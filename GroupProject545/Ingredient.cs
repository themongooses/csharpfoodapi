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
        public int fk_nfact_id { get; set; }
        public int food_id { get; set; }
        public string food_name { get; set; }
        public bool in_fridge { get; set; }
    }

    class IngredientPost
    {
        public int food_id { get; set; }
    }
}
