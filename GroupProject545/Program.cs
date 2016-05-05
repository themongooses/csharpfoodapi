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
            RecipePost recipe = new RecipePost();
            recipe.rec_name = "David's food";
            recipe.instructions = "David's instructions for said food item";
            recipe.ingredients_post.Add(new IngredientPost {food_id = 1}); //errors here
            recipe.category = "entree";
            recipe.CreateRecipe(recipe);
        }
    }

}
