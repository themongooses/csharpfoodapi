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
            API api = new API();
            List<Food> list_of_food = new List<Food> {
				new Food {
					fk_nfact_id = 1,
					food_name = "a food to update",
					food_id = 1,
					in_fridge = false
				},
				new Food {
					fk_nfact_id = 2,
					food_name = "A new food item",
					in_fridge = true,
					nutrition = new Nutrition {
						nfact_id = 2,
						sodium = (float)0.00,
						fat = (float)0.00,
						calories = 100,
						food_group = "grain",
						amount = (float)10.53
					}
				}
			};

			var response  = api.CreateOrUpdateFood(list_of_food);
			foreach(var food in response){
				Console.WriteLine(food);
			}
			Console.ReadLine();
        }
    }
}
