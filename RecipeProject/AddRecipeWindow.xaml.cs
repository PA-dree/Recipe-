using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeProject
{
    public partial class AddRecipeWindow : Window
    {
        public Recipe NewRecipe { get; private set; }
        private Ingredient currentIngredient;

        public AddRecipeWindow()
        {
            InitializeComponent();
            NewRecipe = new Recipe();
            currentIngredient = new Ingredient();
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Recipe Name" || textBox.Text == "Ingredient Name" ||
                textBox.Text == "Quantity" || textBox.Text == "Unit of Measurement" ||
                textBox.Text == "Calories" || textBox.Text == "Food Group")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "RecipeNameTextBox":
                        textBox.Text = "Recipe Name";
                        break;
                    case "IngredientNameTextBox":
                        textBox.Text = "Ingredient Name";
                        break;
                    case "QuantityTextBox":
                        textBox.Text = "Quantity";
                        break;
                    case "UnitTextBox":
                        textBox.Text = "Unit of Measurement";
                        break;
                    case "CaloriesTextBox":
                        textBox.Text = "Calories";
                        break;
                    case "FoodGroupTextBox":
                        textBox.Text = "Food Group";
                        break;
                }
                textBox.Foreground = Brushes.Gray;
            }
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            currentIngredient.Name = IngredientNameTextBox.Text;
            currentIngredient.Quantity = double.Parse(QuantityTextBox.Text);
            currentIngredient.UnitOfMeasurement = UnitTextBox.Text;
            currentIngredient.Calories = int.Parse(CaloriesTextBox.Text);
            currentIngredient.FoodGroup = FoodGroupTextBox.Text;
            NewRecipe.Ingredients.Add(currentIngredient);
            currentIngredient = new Ingredient();
            MessageBox.Show("Ingredient added.");
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe.Name = RecipeNameTextBox.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}

