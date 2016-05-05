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
            Recipe recipe = new Recipe();
            Ingredient ingredient = new Ingredient();
            recipe.rec_name = "David's food";
            recipe.instructions = "David's instructions for said food item";
            recipe.ingredients.Add(new Ingredient() { food_id = 2 }); //errors here
            recipe.ingredients.Add(new Ingredient() { food_id = 1 }); //and here
            recipe.category = "entree";
            recipe.CreateRecipe(recipe);
        }
    }

}
