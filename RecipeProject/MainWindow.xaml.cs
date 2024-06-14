using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RecipeProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            string ingredientFilter = IngredientFilterTextBox.Text != "Enter ingredient name" ? IngredientFilterTextBox.Text.ToLower() : "";
            string foodGroupFilter = FoodGroupFilterTextBox.Text != "Enter food group" ? FoodGroupFilterTextBox.Text.ToLower() : "";
            int maxCalories = int.TryParse(MaxCaloriesFilterTextBox.Text, out int result) ? result : int.MaxValue;

            // Use ingredientFilter, foodGroupFilter, and maxCalories variables as needed...
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            IngredientFilterTextBox.Text = "Enter ingredient name";
            IngredientFilterTextBox.Foreground = Brushes.Gray;
            FoodGroupFilterTextBox.Text = "Enter food group";
            FoodGroupFilterTextBox.Foreground = Brushes.Gray;
            MaxCaloriesFilterTextBox.Text = "Enter max calories";
            MaxCaloriesFilterTextBox.Foreground = Brushes.Gray;

            // Additional logic to clear filters...
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Enter ingredient name" || textBox.Text == "Enter food group" || textBox.Text == "Enter max calories")
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
                    case "IngredientFilterTextBox":
                        textBox.Text = "Enter ingredient name";
                        break;
                    case "FoodGroupFilterTextBox":
                        textBox.Text = "Enter food group";
                        break;
                    case "MaxCaloriesFilterTextBox":
                        textBox.Text = "Enter max calories";
                        break;
                }
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}
