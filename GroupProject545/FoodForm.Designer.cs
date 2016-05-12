using System.Windows.Forms;

namespace GroupProject545
{
    partial class FoodForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.shoppingButton = new System.Windows.Forms.Button();
            this.foodButton = new System.Windows.Forms.Button();
            this.fridgeButton = new System.Windows.Forms.Button();
            this.recipeButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.mainListView = new System.Windows.Forms.ListView();
            this.fromListView = new System.Windows.Forms.ListView();
            this.viewLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.removeFromListButton = new System.Windows.Forms.Button();
            this.addToListButton = new System.Windows.Forms.Button();
            this.addToListButtonFridge = new System.Windows.Forms.Button();
            this.toListView = new System.Windows.Forms.ListView();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timeOfDayComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.foodNameTextBox = new System.Windows.Forms.TextBox();
            this.foodNameLabel = new System.Windows.Forms.Label();
            this.inFridgeCheckBox = new System.Windows.Forms.CheckBox();
            this.calorieTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.fatTextBox = new System.Windows.Forms.TextBox();
            this.sodiumTextBox = new System.Windows.Forms.TextBox();
            this.sugarTextBox = new System.Windows.Forms.TextBox();
            this.calorieLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.fatLabel = new System.Windows.Forms.Label();
            this.sodiumLabel = new System.Windows.Forms.Label();
            this.sugarLabel = new System.Windows.Forms.Label();
            this.foodGroupComboBox = new System.Windows.Forms.ComboBox();
            this.foodGroupLabel = new System.Windows.Forms.Label();
            this.proteinLabel = new System.Windows.Forms.Label();
            this.proteinTextBox = new System.Windows.Forms.TextBox();
            this.recipeNameTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.instructionsTextBox = new System.Windows.Forms.TextBox();
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // shoppingButton
            // 
            this.shoppingButton.Location = new System.Drawing.Point(32, 32);
            this.shoppingButton.Name = "shoppingButton";
            this.shoppingButton.Size = new System.Drawing.Size(172, 32);
            this.shoppingButton.TabIndex = 0;
            this.shoppingButton.Text = "View Shopping List";
            this.shoppingButton.UseVisualStyleBackColor = true;
            this.shoppingButton.Click += new System.EventHandler(this.shoppingButton_Click);
            // 
            // foodButton
            // 
            this.foodButton.Location = new System.Drawing.Point(32, 70);
            this.foodButton.Name = "foodButton";
            this.foodButton.Size = new System.Drawing.Size(172, 32);
            this.foodButton.TabIndex = 1;
            this.foodButton.Text = "View Foods";
            this.foodButton.UseVisualStyleBackColor = true;
            this.foodButton.Click += new System.EventHandler(this.foodButton_Click);
            // 
            // fridgeButton
            // 
            this.fridgeButton.Location = new System.Drawing.Point(32, 108);
            this.fridgeButton.Name = "fridgeButton";
            this.fridgeButton.Size = new System.Drawing.Size(172, 32);
            this.fridgeButton.TabIndex = 2;
            this.fridgeButton.Text = "View Fridge";
            this.fridgeButton.UseVisualStyleBackColor = true;
            this.fridgeButton.Click += new System.EventHandler(this.fridgeButton_Click);
            // 
            // recipeButton
            // 
            this.recipeButton.Location = new System.Drawing.Point(32, 146);
            this.recipeButton.Name = "recipeButton";
            this.recipeButton.Size = new System.Drawing.Size(172, 32);
            this.recipeButton.TabIndex = 3;
            this.recipeButton.Text = "View Recipes";
            this.recipeButton.UseVisualStyleBackColor = true;
            this.recipeButton.Click += new System.EventHandler(this.recipeButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(32, 184);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(172, 32);
            this.menuButton.TabIndex = 4;
            this.menuButton.Text = "View Menus";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // mainListView
            // 
            this.mainListView.Location = new System.Drawing.Point(230, 70);
            this.mainListView.Name = "mainListView";
            this.mainListView.Size = new System.Drawing.Size(444, 278);
            this.mainListView.TabIndex = 5;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            mainListView.View = View.Details;
            mainListView.Click += new System.EventHandler(mainListView_Click);
            // 
            // addFromListView
            // 
            this.fromListView.Location = new System.Drawing.Point(230, 163);
            this.fromListView.Name = "fromListView";
            this.fromListView.Size = new System.Drawing.Size(200, 147);
            this.fromListView.TabIndex = 96;
            this.fromListView.UseCompatibleStateImageBehavior = false;
            fromListView.View = View.Details;
            // 
            // viewLabel
            // 
            this.viewLabel.AutoSize = true;
            this.viewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLabel.Location = new System.Drawing.Point(227, 32);
            this.viewLabel.Name = "viewLabel";
            this.viewLabel.Size = new System.Drawing.Size(78, 18);
            this.viewLabel.TabIndex = 9;
            this.viewLabel.Text = "View Label";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // removeFromListButton
            // 
            this.removeFromListButton.Image = global::GroupProject545.Properties.Resources.BackImage;
            this.removeFromListButton.Location = new System.Drawing.Point(436, 239);
            this.removeFromListButton.Name = "removeFromListButton";
            this.removeFromListButton.Size = new System.Drawing.Size(32, 32);
            this.removeFromListButton.TabIndex = 98;
            this.removeFromListButton.UseVisualStyleBackColor = true;
            removeFromListButton.Click += new System.EventHandler(removeFromListButton_Click);
            // 
            // addToListButton
            // 
            this.addToListButton.Image = global::GroupProject545.Properties.Resources.ForwardImage;
            this.addToListButton.Location = new System.Drawing.Point(436, 201);
            this.addToListButton.Name = "addToListButton";
            this.addToListButton.Size = new System.Drawing.Size(32, 32);
            this.addToListButton.TabIndex = 97;
            this.addToListButton.UseVisualStyleBackColor = true;
            addToListButton.Click += new System.EventHandler(addToListButton_Click);
            // 
            // addToListButton (Fridge)
            // 
            this.addToListButtonFridge.Image = global::GroupProject545.Properties.Resources.ForwardImage;
            this.addToListButtonFridge.Location = new System.Drawing.Point(436, 201);
            this.addToListButtonFridge.Name = "addToListButtonFridge";
            this.addToListButtonFridge.Size = new System.Drawing.Size(32, 32);
            this.addToListButtonFridge.TabIndex = 97;
            this.addToListButtonFridge.UseVisualStyleBackColor = true;
            addToListButtonFridge.Click += new System.EventHandler(addToListButtonFridge_Click);
            // 
            // addToListView
            // 
            this.toListView.Location = new System.Drawing.Point(474, 163);
            this.toListView.Name = "toListView";
            this.toListView.Size = new System.Drawing.Size(200, 147);
            this.toListView.TabIndex = 99;
            this.toListView.UseCompatibleStateImageBehavior = false;
            toListView.View = View.Details;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(474, 70);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 11;
            // 
            // timePicker
            // 
            this.timeOfDayComboBox.FormattingEnabled = true;
            this.timeOfDayComboBox.Items.AddRange(new object[] {
            "Breakfast",
            "Lunch",
            "Dinner"});
            this.timeOfDayComboBox.Location = new System.Drawing.Point(474, 98);
            this.timeOfDayComboBox.Name = "timeOfDayComboBox";
            this.timeOfDayComboBox.Size = new System.Drawing.Size(200, 55);
            this.timeOfDayComboBox.TabIndex = 12;
            // 
            // saveButton
            // 
            this.saveButton.Image = global::GroupProject545.Properties.Resources.AddImage;
            this.saveButton.Location = new System.Drawing.Point(642, 316);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(32, 32);
            this.saveButton.TabIndex = 100;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(saveButton_click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(502, 354);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(172, 32);
            this.addButton.TabIndex = 14;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_click);
            // 
            // foodNameTextBox
            // 
            this.foodNameTextBox.Location = new System.Drawing.Point(320, 70);
            this.foodNameTextBox.Name = "foodNameTextBox";
            this.foodNameTextBox.Size = new System.Drawing.Size(110, 22);
            this.foodNameTextBox.TabIndex = 15;
            // 
            // foodNameLabel
            // 
            this.foodNameLabel.AutoSize = true;
            this.foodNameLabel.Location = new System.Drawing.Point(227, 75);
            this.foodNameLabel.Name = "foodNameLabel";
            this.foodNameLabel.Size = new System.Drawing.Size(81, 17);
            this.foodNameLabel.TabIndex = 16;
            this.foodNameLabel.Text = "Food Name";
            // 
            // inFridgeCheckBox
            // 
            this.inFridgeCheckBox.AutoSize = true;
            this.inFridgeCheckBox.Location = new System.Drawing.Point(320, 128);
            this.inFridgeCheckBox.Name = "inFridgeCheckBox";
            this.inFridgeCheckBox.Size = new System.Drawing.Size(121, 21);
            this.inFridgeCheckBox.TabIndex = 19;
            this.inFridgeCheckBox.Text = "Food in Fridge";
            this.inFridgeCheckBox.UseVisualStyleBackColor = true;
            // 
            // calorieTextBox
            // 
            this.calorieTextBox.Location = new System.Drawing.Point(563, 70);
            this.calorieTextBox.Name = "calorieTextBox";
            this.calorieTextBox.Size = new System.Drawing.Size(110, 22);
            this.calorieTextBox.TabIndex = 20;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(563, 98);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(110, 22);
            this.amountTextBox.TabIndex = 21;
            // 
            // fatTextBox
            // 
            this.fatTextBox.Location = new System.Drawing.Point(563, 126);
            this.fatTextBox.Name = "fatTextBox";
            this.fatTextBox.Size = new System.Drawing.Size(110, 22);
            this.fatTextBox.TabIndex = 22;
            // 
            // sodiumTextBox
            // 
            this.sodiumTextBox.Location = new System.Drawing.Point(563, 154);
            this.sodiumTextBox.Name = "sodiumTextBox";
            this.sodiumTextBox.Size = new System.Drawing.Size(110, 22);
            this.sodiumTextBox.TabIndex = 23;
            // 
            // sugarTextBox
            // 
            this.sugarTextBox.Location = new System.Drawing.Point(563, 182);
            this.sugarTextBox.Name = "sugarTextBox";
            this.sugarTextBox.Size = new System.Drawing.Size(110, 22);
            this.sugarTextBox.TabIndex = 24;
            // 
            // calorieLabel
            // 
            this.calorieLabel.AutoSize = true;
            this.calorieLabel.Location = new System.Drawing.Point(471, 73);
            this.calorieLabel.Name = "calorieLabel";
            this.calorieLabel.Size = new System.Drawing.Size(59, 17);
            this.calorieLabel.TabIndex = 25;
            this.calorieLabel.Text = "Calories";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(471, 101);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(56, 17);
            this.amountLabel.TabIndex = 26;
            this.amountLabel.Text = "Amount";
            // 
            // fatLabel
            // 
            this.fatLabel.AutoSize = true;
            this.fatLabel.Location = new System.Drawing.Point(471, 129);
            this.fatLabel.Name = "fatLabel";
            this.fatLabel.Size = new System.Drawing.Size(28, 17);
            this.fatLabel.TabIndex = 27;
            this.fatLabel.Text = "Fat";
            // 
            // sodiumLabel
            // 
            this.sodiumLabel.AutoSize = true;
            this.sodiumLabel.Location = new System.Drawing.Point(471, 157);
            this.sodiumLabel.Name = "sodiumLabel";
            this.sodiumLabel.Size = new System.Drawing.Size(55, 17);
            this.sodiumLabel.TabIndex = 28;
            this.sodiumLabel.Text = "Sodium";
            // 
            // sugarLabel
            // 
            this.sugarLabel.AutoSize = true;
            this.sugarLabel.Location = new System.Drawing.Point(471, 185);
            this.sugarLabel.Name = "sugarLabel";
            this.sugarLabel.Size = new System.Drawing.Size(46, 17);
            this.sugarLabel.TabIndex = 29;
            this.sugarLabel.Text = "Sugar";
            // 
            // foodGroupComboBox
            // 
            this.foodGroupComboBox.FormattingEnabled = true;
            this.foodGroupComboBox.Items.AddRange(new object[] {
            "Vegitable",
            "Fruit",
            "Grain",
            "Meat",
            "Dairy"});
            this.foodGroupComboBox.Location = new System.Drawing.Point(320, 98);
            this.foodGroupComboBox.Name = "foodGroupComboBox";
            this.foodGroupComboBox.Size = new System.Drawing.Size(110, 25);
            this.foodGroupComboBox.TabIndex = 17;
            // 
            // foodGroupLabel
            // 
            this.foodGroupLabel.AutoSize = true;
            this.foodGroupLabel.Location = new System.Drawing.Point(227, 105);
            this.foodGroupLabel.Name = "foodGroupLabel";
            this.foodGroupLabel.Size = new System.Drawing.Size(84, 17);
            this.foodGroupLabel.TabIndex = 18;
            this.foodGroupLabel.Text = "Food Group";
            // 
            // proteinLabel
            // 
            this.proteinLabel.AutoSize = true;
            this.proteinLabel.Location = new System.Drawing.Point(471, 213);
            this.proteinLabel.Name = "proteinLabel";
            this.proteinLabel.Size = new System.Drawing.Size(53, 17);
            this.proteinLabel.TabIndex = 30;
            this.proteinLabel.Text = "Protein";
            // 
            // proteinTextBox
            // 
            this.proteinTextBox.Location = new System.Drawing.Point(563, 210);
            this.proteinTextBox.Name = "proteinTextBox";
            this.proteinTextBox.Size = new System.Drawing.Size(111, 22);
            this.proteinTextBox.TabIndex = 31;
            // 
            // recipeNameTextBox
            // 
            this.recipeNameTextBox.Location = new System.Drawing.Point(316, 70);
            this.recipeNameTextBox.Name = "recipeNameTextBox";
            this.recipeNameTextBox.Size = new System.Drawing.Size(114, 22);
            this.recipeNameTextBox.TabIndex = 101;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Items.AddRange(new object[] {
            "Entree",
            "Appetizer",
            "Dessert"});
            this.categoryComboBox.Location = new System.Drawing.Point(559, 71);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(114, 25);
            this.categoryComboBox.TabIndex = 102;
            // 
            // instructionsTextBox
            // 
            this.instructionsTextBox.Location = new System.Drawing.Point(316, 101);
            this.instructionsTextBox.Multiline = true;
            this.instructionsTextBox.Name = "instructionsTextBox";
            this.instructionsTextBox.Size = new System.Drawing.Size(357, 56);
            this.instructionsTextBox.TabIndex = 103;
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Location = new System.Drawing.Point(230, 73);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(45, 17);
            this.recipeNameLabel.TabIndex = 104;
            this.recipeNameLabel.Text = "Name";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(471, 73);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(65, 17);
            this.categoryLabel.TabIndex = 105;
            this.categoryLabel.Text = "Category";
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(230, 104);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(80, 17);
            this.instructionsLabel.TabIndex = 106;
            this.instructionsLabel.Text = "Instructions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 538);

            this.Name = "Form1";
            this.Text = "Team Mongoose - Fridge System";
            this.ResumeLayout(false);
            ShoppingListScreen();
        }

        #endregion

        private System.Windows.Forms.Button shoppingButton;
        private System.Windows.Forms.Button foodButton;
        private System.Windows.Forms.Button fridgeButton;
        private System.Windows.Forms.Button recipeButton;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ListView fromListView;
        private System.Windows.Forms.Button addToListButton;
        private System.Windows.Forms.Button addToListButtonFridge;
        private System.Windows.Forms.Button removeFromListButton;
        private System.Windows.Forms.Label viewLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView toListView;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox timeOfDayComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox foodNameTextBox;
        private System.Windows.Forms.Label foodNameLabel;
        private System.Windows.Forms.CheckBox inFridgeCheckBox;
        private System.Windows.Forms.TextBox calorieTextBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox fatTextBox;
        private System.Windows.Forms.TextBox sodiumTextBox;
        private System.Windows.Forms.TextBox sugarTextBox;
        private System.Windows.Forms.Label calorieLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label fatLabel;
        private System.Windows.Forms.Label sodiumLabel;
        private System.Windows.Forms.Label sugarLabel;
        private System.Windows.Forms.ComboBox foodGroupComboBox;
        private System.Windows.Forms.Label foodGroupLabel;
        private System.Windows.Forms.Label proteinLabel;
        private System.Windows.Forms.TextBox proteinTextBox;
        private System.Windows.Forms.TextBox recipeNameTextBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox instructionsTextBox;
        private System.Windows.Forms.Label recipeNameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label instructionsLabel;
    }
}

