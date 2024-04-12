using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Recipe
{
    public class Recipe
    {
        public int IngredientCount { get; set; }
        public string[] Ingredients { get; set; }
        public int StepCount { get; set; }
        public string[] Steps { get; set; }

        public Recipe()
        {
            // Default constructor to initialize arrays
            Ingredients = new string[IngredientCount];
            Steps = new string[StepCount];
        }

        public void DisplayRecipe()
        {
            // Display the full recipe, including ingredients and steps
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < IngredientCount; i++)
            {
                Console.WriteLine($"{Ingredients[i]}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < StepCount; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            // Scale the quantities of all ingredients by the given factor
            for (int i = 0; i < IngredientCount; i++)
            {
                // Split the ingredient into quantity and unit
                string[] parts = Ingredients[i].Split(' ');
                if (parts.Length == 3)
                {
                    double quantity = double.Parse(parts[0]);
                    string unit = parts[1];
                    string ingredient = parts[2];

                    // Scale the quantity
                    quantity *= factor;

                    // Update the ingredient with the scaled quantity
                    Ingredients[i] = $"{quantity} {unit} {ingredient}";
                }
            }
        }
    }
    //Step 2: Implement the user interface

    //Next, we need to implement the user interface for the console application.We will create a main method that interacts with the user, allows them to enter the recipe details, and performs the requested actions.


class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine("Enter the recipe details:");

                Console.Write("Number of ingredients: ");
                recipe.IngredientCount = int.Parse(Console.ReadLine());
                recipe.Ingredients = new string[recipe.IngredientCount];
                for (int i = 0; i < recipe.IngredientCount; i++)
                {
                    Console.Write($"Ingredient {i + 1}: ");
                    recipe.Ingredients[i] = Console.ReadLine();
                }

                Console.Write("Number of steps: ");
                recipe.StepCount = int.Parse(Console.ReadLine());
                recipe.Steps = new string[recipe.StepCount];
                for (int i = 0; i < recipe.StepCount; i++)
                {
                    Console.Write($"Step {i + 1}: ");
                    recipe.Steps[i] = Console.ReadLine();
                }

                Console.WriteLine();
                recipe.DisplayRecipe();

                Console.WriteLine();
                Console.WriteLine("Enter a scaling factor (0.5, 2, 3) or type 'reset' to reset quantities or 'clear' to enter a new recipe:");
                string input = Console.ReadLine();

                if (input == "reset")
                {
                    // Reset quantities to original values
                    // Re-enter recipe details
                    continue;
                }
                else if (input == "clear")
                {
                    // Clear all data to enter a new recipe
                    recipe = new Recipe();
                    continue;
                }

                double scalingFactor;
                if (double.TryParse(input, out scalingFactor))
                {
                    // Scale the recipe quantities
                    recipe.ScaleRecipe(scalingFactor);

                    Console.WriteLine();
                    recipe.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }

}
