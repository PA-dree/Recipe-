using System.Windows;

namespace RecipeProject
{
    public partial class ScaleRecipeWindow : Window
    {
        private Recipe recipe;

        public ScaleRecipeWindow(Recipe recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            double scaleFactor = 1;
            if (HalfRadioButton.IsChecked == true) scaleFactor = 0.5;
            else if (DoubleRadioButton.IsChecked == true) scaleFactor = 2;
            else if (TripleRadioButton.IsChecked == true) scaleFactor = 3;

            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
            this.Close();
            MessageBox.Show("The recipe quantities have been scaled.");
        }
    }
}



