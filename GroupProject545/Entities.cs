using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject545
{
    public class Menu
    {
        public DateTime date { get; set; }
        public int id { get; set; }
        public Recipe[] recipes { get; set; }
        public string time_of_day { get; set; }
    }

    public class MenuPost : Menu
    {
        public string date { get; set; }
        public List<int> recipes { get; set; }
    }

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

    public class Food
    {
        public int fk_nfact_id { get; set; }
        public int food_id { get; set; }
        public string food_name { get; set; }
        public bool in_fridge { get; set; }
        public Nutrition nutrition { get; set; }
    }

    public class Nutrition
    {
        public float amount { get; set; }
        public float calories { get; set; }
        public float fat { get; set; }
        public string food_group { get; set; }
        public int nfact_id { get; set; }
        public float protein { get; set; }
        public float sodium { get; set; }
        public float sugar { get; set; }
    }


}
