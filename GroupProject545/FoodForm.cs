using System;
using System.Windows.Forms;
using GroupProject545;
using FoodAPI;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroupProject545
{
    public partial class FoodForm : Form
    {
        public FoodForm()
        {
            InitializeComponent();
        }

        //ClearScreen resets the screen with the menu buttons.
        private void ClearScreen()
        {
            Controls.Clear();

            viewLabel.Text = "";

            Controls.Add(viewLabel);
            Controls.Add(shoppingButton);
            Controls.Add(fridgeButton);
            Controls.Add(foodButton);
            Controls.Add(recipeButton);
            Controls.Add(menuButton);
        }

        //ViewScreen takes a string s, representing the menu the user is on.
        //ViewScreen sets the label and adds the main ListView.
        private void ViewScreen(String s)
        {
            ClearScreen();
            viewLabel.Text = s;
            Controls.Add(mainListView);
        }

        //EditableViewScreen takes string s, representing the menu the user is on.
        //EditableViewScreen calls ViewScreen, then adds the add Button.
        private void EditableViewScreen(String s)
        {
            ViewScreen(s);
            Controls.Add(addButton);
        }

        //ShoppingListScreen is a ViewScreen.
        //ShoppingListScreen adds specific columns to the main ListView.
        private void ShoppingListScreen()
        {
            ViewScreen("Shopping List");

            string[] columns = { "Food Name" };

            addListViewColumns(mainListView, columns);
        }

        //SavableScreen takes string s, representing the menu the user is on.
        //SavableScreen clears the screen, sets the label, then adds the save Button.
        private void SavableScreen(String s)
        {
            ClearScreen();
            viewLabel.Text = s;
            Controls.Add(saveButton);
        }

        //FridgeScreen is an EditableViewScreen.
        //FridgeScreen adds specific columns to the main ListView.
        private void FridgeScreen()
        {
            EditableViewScreen("Fridge");

            string[] columns = { "Food Name" };

            addListViewColumns(mainListView, columns);

            API api = new API();
            var fridge_response = api.GetFridge();
            foreach (var food in fridge_response)
            {
                string[] row = { food.food_name };
                var listViewItem = new ListViewItem(row);
                mainListView.Items.Add(listViewItem);
            }
        }

        //FoodScreen is an EditableViewScreen.
        //FoodScreen adds specific columns to the main ListView.
        private void FoodScreen()
        {
            EditableViewScreen("Food");

            string[] columns = { "Name", "Food Group", "Calories", "Amount", "Fat", "Sodium", "Sugar", "Protein" };

            addListViewColumns(mainListView, columns);

            API api = new API();
            var food_response = api.GetFoods();
            foreach (var food in food_response)
            {

                string[] row = { food.food_name, food.nutrition.food_group, Convert.ToString(food.nutrition.calories), Convert.ToString(food.nutrition.amount), Convert.ToString(food.nutrition.fat), Convert.ToString(food.nutrition.sodium), Convert.ToString(food.nutrition.sugar), Convert.ToString(food.nutrition.protein) };
                var listViewItem = new ListViewItem(row);
                mainListView.Items.Add(listViewItem);
            }
        }

        //RecipeScreen is an EditableViewScreen.
        //RecipeScreen adds specific columns to the main ListView.
        private void RecipeScreen()
        {
            EditableViewScreen("Recipe");

            string[] columns = { "Name", "Category", "Instructions" };

            addListViewColumns(mainListView, columns);
            API api = new API();
            var recipe_response = api.GetRecipes();
            foreach (var recipe in recipe_response)
            {

                string[] row = { recipe.rec_name, recipe.category, recipe.instructions };
                var listViewItem = new ListViewItem(row);
                mainListView.Items.Add(listViewItem);
            }
        }

        //MenuScreen is an EdibableViewScreen.
        //MenuScreen adds specific columns to the main ListView.
        private void MenuScreen()
        {
            EditableViewScreen("Menu");

            string[] columns = { "Date", "Time of Day" };

            addListViewColumns(mainListView, columns);

            API api = new API();
            var menu_response = api.GetMenus();
            foreach (var menu in menu_response)
            {
                String date = menu.date.ToString("yyyy-MM-dd");
                string[] row = { date, menu.time_of_day };
                var listViewItem = new ListViewItem(row);
                mainListView.Items.Add(listViewItem);
            }
        }

        //AddFoodScreen is a SavableScreen.
        //Adds various controls to create a food object.
        private void AddFoodScreen()
        {
            SavableScreen("Food");

            amountTextBox.Text = "";
            calorieTextBox.Text = "";
            fatTextBox.Text = "";
            foodNameTextBox.Text = "";
            proteinTextBox.Text = "";
            sodiumTextBox.Text = "";
            sugarTextBox.Text = "";
            foodGroupComboBox.Text = "";
            inFridgeCheckBox.Checked = false;

            Controls.Add(foodNameLabel);
            Controls.Add(foodNameTextBox);
            Controls.Add(inFridgeCheckBox);
            Controls.Add(foodGroupLabel);
            Controls.Add(foodGroupComboBox);
            Controls.Add(calorieLabel);
            Controls.Add(calorieTextBox);
            Controls.Add(amountLabel);
            Controls.Add(amountTextBox);
            Controls.Add(fatLabel);
            Controls.Add(fatTextBox);
            Controls.Add(sodiumLabel);
            Controls.Add(sodiumTextBox);
            Controls.Add(proteinLabel);
            Controls.Add(proteinTextBox);
            Controls.Add(sugarLabel);
            Controls.Add(sugarTextBox);
        }

        //AddFridgeScreen is a SavableScreen.
        //AddFridgeScreen adds specific columns to the to and from ListViews
        //AddFridgeScreen adds various controls to move food into the Fridge.
        private void AddFridgeScreen()
        {
            string[] columns = { "Food Name" };

            addListViewColumns(fromListView, columns);
            addListViewColumns(toListView, columns);

            API api = new API();
            var fridge_response = api.GetFridge();
            foreach (var fridge in fridge_response)
            {

                string[] row = { fridge.food_name };
                var listViewItem = new ListViewItem(row);
                fromListView.Items.Add(listViewItem);
            }

            var food_response = api.GetFoods();
            foreach (var food in food_response)
            {
                if (food.in_fridge != true)
                {
                    string[] row = { food.food_name };
                    var listViewItem = new ListViewItem(row);
                    toListView.Items.Add(listViewItem);
                }

            }

            SavableScreen("Fridge");

            this.fromListView.Size = new System.Drawing.Size(200, 240);
            this.toListView.Size = new System.Drawing.Size(200, 240);

            this.fromListView.Location = new System.Drawing.Point(230, 70);
            this.addToListButtonFridge.Location = new System.Drawing.Point(436, 156);
            this.removeFromListButton.Location = new System.Drawing.Point(436, 194);
            this.toListView.Location = new System.Drawing.Point(474, 70);
            this.saveButton.Location = new System.Drawing.Point(642, 316);


            Controls.Add(toListView);
            Controls.Add(fromListView);
            Controls.Add(addToListButtonFridge);
            Controls.Add(removeFromListButton);
        }

        //AddRecipeScreen is a SavableScreen.
        //AddRecipeScreen adds specific columns to the to and from ListViews.
        //AddRecipeScreen adds controls to create a Recipe object.
        private void AddRecipeScreen()
        {
            string[] columns = { "Food Name" };

            addListViewColumns(fromListView, columns);
            addListViewColumns(toListView, columns);

            SavableScreen("Recipe");

            this.fromListView.Size = new System.Drawing.Size(200, 147);
            this.toListView.Size = new System.Drawing.Size(200, 147);

            this.fromListView.Location = new System.Drawing.Point(230, 163);
            this.addToListButton.Location = new System.Drawing.Point(436, 201);
            this.removeFromListButton.Location = new System.Drawing.Point(436, 239);
            this.toListView.Location = new System.Drawing.Point(474, 163);
            this.saveButton.Location = new System.Drawing.Point(642, 316);

            Controls.Add(recipeNameLabel);
            Controls.Add(recipeNameTextBox);
            Controls.Add(categoryLabel);
            Controls.Add(categoryComboBox);
            Controls.Add(instructionsLabel);
            Controls.Add(instructionsTextBox);

            Controls.Add(toListView);
            Controls.Add(fromListView);
            Controls.Add(addToListButton);
            Controls.Add(removeFromListButton);
            Controls.Add(saveButton);
        }

        //AddMenuScreen is a SavableScreen.
        //AddMenuScreen adds specific columns to the to and from ListViews.
        //AddMenuScreen adds controls to create a Menu object.
        private void AddMenuScreen()
        {
            string[] columns = { "Recipe Name" };

            addListViewColumns(fromListView, columns);
            addListViewColumns(toListView, columns);

            SavableScreen("Menu");


            this.fromListView.Size = new System.Drawing.Size(200, 147);
            this.toListView.Size = new System.Drawing.Size(200, 147);

            this.fromListView.Location = new System.Drawing.Point(230, 163);
            this.addToListButton.Location = new System.Drawing.Point(436, 201);
            this.removeFromListButton.Location = new System.Drawing.Point(436, 239);
            this.toListView.Location = new System.Drawing.Point(474, 163);
            this.saveButton.Location = new System.Drawing.Point(642, 316);


            Controls.Add(datePicker);
            Controls.Add(timeOfDayComboBox);
            Controls.Add(toListView);
            Controls.Add(fromListView);
            Controls.Add(addToListButton);
            Controls.Add(removeFromListButton);
            Controls.Add(saveButton);
        }

        //AddFood verifies the user input on the AddFoodScreen and creates a Food object.
        private void AddFood()
        {
            try
            {
                //Pull user input
                string name = foodNameTextBox.Text;
                string group = foodGroupComboBox.Text.ToLower();
                bool inFridge = inFridgeCheckBox.Checked;

                int n_calories = int.Parse(calorieTextBox.Text);
                int n_amount = int.Parse(amountTextBox.Text);
                int n_fat = int.Parse(fatTextBox.Text);
                int n_sodium = int.Parse(sodiumTextBox.Text);
                int n_sugar = int.Parse(sugarTextBox.Text);
                int n_protein = int.Parse(proteinTextBox.Text);

                //Check that name is not an empty string.
                if (!name.Equals(""))
                {
                    //Checks that group fits the enum("fruit", "vegitable", "grain", "meat", "dairy")
                    if (group.Equals("fruit") || group.Equals("vegitable") || group.Equals("grain") ||
                        group.Equals("meat") || group.Equals("dairy"))
                    {
                        //Add code to add food to cache
                        API api = new API();
                        List<Nutrition> n = new List<Nutrition> {
                            new Nutrition {
                                sodium = n_sodium,
						        fat = n_fat,
						        calories = n_calories,
						        food_group = group,
                                sugar = n_sugar,
                                protein = n_protein,
						        amount = n_amount
                            }
                        };

                        var nutrition_response = api.CreateOrUpdateNutrition(n);
                        int n_fact_id;

                        foreach (var nutrition in nutrition_response)
                        {
                            n_fact_id = nutrition.nfact_id;

                            List<Food> f = new List<Food> {
                            new Food {
					        food_name = name,
					        in_fridge = inFridge,
                            fk_nfact_id = n_fact_id,
				           }
                        };

                            var response = api.CreateOrUpdateFood(f);
                            foreach (var food in response)
                            {
                                if (food.food_name != null)
                                {
                                    MessageBox.Show(food.food_name + " has been successfully added");
                                }
                            }
                        }

                        //Return to Food Screen
                        FoodScreen();
                    }
                    else
                    {
                        //Alert the user that the food group is invalid.
                        MessageBox.Show("Invalid Food Group!");
                    }
                }
                else
                {
                    //Alert the user their food name is invalid.
                    MessageBox.Show("Food must have a name!");
                }

            }
            catch (Exception)
            {
                //Alert the user that nutrient facts are invalid.
                MessageBox.Show("Nutrient facts must be whole numbers!");
            }
        }

        //AddFridge changes a Food objects in_fridge value based on user action on AddFridgeScreen.
        private void AddFridge()
        {
            try
            {
                //For each food within the from ListView
                for (int i = 0; i < fromListView.Items.Count; i++)
                {
                    //Addcode to update cached food, ensure each food is not inFridge
                    var food_id = fromListView.Items[i].Tag;
                }

                //For each food within the to ListView
                for (int i = 0; i < toListView.Items.Count; i++)
                {
                    //Add code to update cached food, ensuring each food is inFridge
                    var food_id = toListView.Items[i].Tag;
                }

                //Return to the FridgeScreen if no error has occured.
                FridgeScreen();
            }
            catch (Exception e)
            {
                //Alert the user that some unknown error has occured.
                MessageBox.Show("An error occured updating fridge.");
            }
        }

        //AddRecipe verifies the user input on the AddRecipeScreen and creates a Recipe object.
        private void AddRecipe()
        {
            //Pull user input
            string name = recipeNameTextBox.Text;
            string category = categoryComboBox.Text.ToLower();
            string instructions = instructionsTextBox.Text;

            //Verifies the name is not an empty string.
            if (!name.Equals(""))
            {
                //Verified the instructions are not an empty string.
                if (!instructions.Equals(""))
                {
                    //Verified the category is within the enum("entree", "appetizer", "dessert")
                    if (category.Equals("entree") || category.Equals("appetizer") || category.Equals("dessert"))
                    {
                        //Replace with creating recipe item, adding to cache, and updating the database.
                        API api = new API();
                        List<Recipe> r = new List<Recipe> {
                            new Recipe {
						        rec_name = name,
						        category = category,
						        instructions = instructions
                            }
                        };

                        var recipe_response = api.CreateOrUpdateRecipes(r);

                        foreach (var recipe in recipe_response)
                        {
                            if(recipe.rec_name != null){
                                MessageBox.Show(recipe.rec_name + "Recipe has been added");
                            }
                        }

                        
                        //For each recipe within the to ListView
                        for (int i = 0; i < toListView.Items.Count; i++)
                        {
                            //Add code to add the recipe item to the recipe
                            var rec_id = toListView.Items[i].Tag;
                        }

                        //Return to Food Screen
                        RecipeScreen();
                    }
                    else
                    {
                        //Alert the user the category is invalid.
                        MessageBox.Show("Invalid category!");
                    }
                }
                else
                {
                    //Alert the user the instructions are invalid.
                    MessageBox.Show("Recipe must have instructions!");
                }

            }
            else
            {
                //Alert the user the name is invalid.
                MessageBox.Show("Recipe must have a name!");
            }
        }

        //AddMenu verifies the user input on the AddMenuScreen and creates a Menu object.
        private void AddMenu()
        {
            //Pull User input
            DateTime dt = datePicker.Value;
            string timeOfDay = timeOfDayComboBox.Text.ToLower();

            //Format the date for the database
            string day = dt.Year + "-";

            if (dt.Month < 10)
            {
                day += "0";
            }

            day += dt.Month + "-";

            if (dt.Day < 10)
            {
                day += "0";
            }

            day += dt.Day;

            //Verified the time of day is within enum("breakfast", "lunch", "dinner")
            if (timeOfDay.Equals("breakfast") || timeOfDay.Equals("lunch") || timeOfDay.Equals("dinner"))
            {
                //Replace with creating menu item, adding to cache, and updating the database.
                Console.Out.Write(day + " for " + timeOfDay);

                //For each recipe within the to ListView.
                for (int i = 0; i < toListView.Items.Count; i++)
                {
                    //Add code to add the recipe item to the menu
                    var rec_id = toListView.Items[i].Tag;
                }

                //Return to Food Screen
                MenuScreen();
            }
            else
            {
                //Alert the user their time of day is invalid.
                MessageBox.Show("Invalid time of day!");
            }
        }

        private void shoppingButton_Click(object sender, EventArgs e)
        {
            ShoppingListScreen();
        }

        private void foodButton_Click(object sender, EventArgs e)
        {
            FoodScreen();
        }

        private void fridgeButton_Click(object sender, EventArgs e)
        {
            FridgeScreen();
        }

        private void recipeButton_Click(object sender, EventArgs e)
        {
            RecipeScreen();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            MenuScreen();
        }

        private void addToListButton_Click(object sender, EventArgs e)
        {
            if (fromListView.Items.Count > 0)
            {
                ListViewItem item = fromListView.SelectedItems[0];
                fromListView.Items.Remove(item);
                toListView.Items.Add(item);
            }
        }

        private void addToListButtonFridge_Click(object sender, EventArgs e)
        {
            if (fromListView.Items.Count > 0)
            {
                ListViewItem item = fromListView.SelectedItems[0];
                fromListView.Items.Remove(item);
                toListView.Items.Add(item);
                API api = new API();
                var f = api.GetFood(item.Text);
                var thing = f.FirstOrDefault();
                if (thing != null)
                {
                    MessageBox.Show(thing.food_name + " " + thing.food_id + " " + thing.in_fridge + " " + thing.fk_nfact_id);
                    List<Food> food = new List<Food> {
                    new Food {
                        food_name = thing.food_name,
                        food_id = thing.food_id,
                        in_fridge = false,
                        fk_nfact_id = thing.fk_nfact_id
                    }
                };
                    var food_response = api.CreateOrUpdateFood(food);
                    foreach (var foo in food_response)
                    {
                        MessageBox.Show(foo.food_name + " is out of the fridge");
                    }
                }
            }
        }

        private void removeFromListButton_Click(object sender, EventArgs e)
        {
            if (toListView.Items.Count > 0)
            {
                ListViewItem item = toListView.SelectedItems[0];
                toListView.Items.Remove(item);
                fromListView.Items.Add(item);
            }
        }

        private void addButton_click(object sender, EventArgs e)
        {
            string s = viewLabel.Text;

            switch (s)
            {
                case "Food":
                    AddFoodScreen();
                    break;
                case "Fridge":
                    AddFridgeScreen();
                    break;
                case "Recipe":
                    AddRecipeScreen();
                    break;
                case "Menu":
                    AddMenuScreen();
                    break;
                default:
                    ShoppingListScreen();
                    break;
            }
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            string s = viewLabel.Text;

            switch (s)
            {
                case "Food":
                    AddFood();
                    break;
                case "Fridge":
                    AddFridge();
                    break;
                case "Recipe":
                    AddRecipe();
                    break;
                case "Menu":
                    AddMenu();
                    break;
                default:
                    //
                    break;
            }
        }

        private void mainListView_Click(object sender, EventArgs e)
        {
            Console.Out.WriteLine(mainListView.FocusedItem.Text);
        }

        private void addListViewColumns(ListView v, string[] c)
        {
            v.Clear();

            foreach (string s in c)
            {
                v.Columns.Add(s, s.Length * 12);
            }
        }
    }
}
