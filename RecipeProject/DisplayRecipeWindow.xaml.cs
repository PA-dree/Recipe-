using System.Windows;

namespace RecipeProject
{
    public partial class DisplayRecipeWindow : Window
    {
        private Recipe recipe;

        public DisplayRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
            DisplayRecipe();
        }

        private void DisplayRecipe()
        {
            RecipeNameTextBlock.Text = recipe.Name;
            IngredientListView.ItemsSource = recipe.Ingredients;
            TotalCaloriesTextBlock.Text = $"Total Calories: {recipe.CalculateTotalCalories()}";
            if (recipe.CalculateTotalCalories() > 300)
            {
                MessageBox.Show($"WARNING: The total calories for the recipe '{recipe.Name}' exceed 300!");
            }
        }
    }
}
