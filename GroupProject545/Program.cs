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
				Console.WriteLine(food.food_name);
                if (food.nutrition != null)
                {
                    Console.WriteLine(food.nutrition.nfact_id);
                }
			}

            List<Nutrition> list_of_nutrition = new List<Nutrition> {
                new Nutrition {
                    nfact_id = 1,
                    food_group = "grain",
                    fat = 30,
                    amount = 8,
                    calories = 500,
                    protein = 16,
                    sugar = 20,
                    sodium = 31
                },

                new Nutrition {
                    food_group = "veggies",
                    fat = 10,
                    amount = 4,
                    calories = 200,
                    protein = 2,
                    sugar = 1,
                    sodium = 3
                }
            };

            var nfact_response = api.CreateOrUpdateNutrition(list_of_nutrition);
            nfact_response.ForEach(Console.WriteLine);

            var menus_response = api.GetMenus();
            menus_response.ForEach(Console.WriteLine);

            List<Menu> list_of_menus = new List<Menu> {
                new Menu {
                    recipes = int [1, 2, 3],
                    time_of_day = "breakfast",
                    date = new DateTime(2016, 05, 10)
                }
            };

            var new_menu_response = api.CreateOrUpdateMenu(list_of_menus);
            foreach(var menu in new_menu_response) {
                Console.WriteLine(menu.id);
            }
			Console.ReadLine();
        }
    }
}
