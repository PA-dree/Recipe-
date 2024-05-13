using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("Enter the recipe details:");

                Console.Write("Recipe name: ");
                string name = Console.ReadLine();

                Recipe recipe = new Recipe();

                // Set the name of the recipe
                recipe.Name = name;

                Console.Write("Number of ingredients: ");
                recipe.IngredientCount = int.Parse(Console.ReadLine());
                recipe.Ingredients = new List<Ingredient>();
                for (int i = 0; i < recipe.IngredientCount; i++)
                {
                    Console.Write($"Ingredient {i + 1}: ");
                    string ingredientName = Console.ReadLine();

                    Console.Write($"Number of calories for {ingredientName}: ");
                    int calories = int.Parse(Console.ReadLine());

                    Console.Write($"Food group for {ingredientName}: ");
                    string foodGroup = Console.ReadLine();

                    // Create a new Ingredient object and add it to the recipe's list of ingredients
                    Ingredient ingredient = new Ingredient(ingredientName, calories, foodGroup);
                    recipe.Ingredients.Add(ingredient);
                }

                Console.Write("Number of steps: ");
                recipe.StepCount = int.Parse(Console.ReadLine());
                recipe.Steps = new List<string>();
                for (int i = 0; i < recipe.StepCount; i++)
                {
                    Console.Write($"Step {i + 1}: ");
                    recipe.Steps.Add(Console.ReadLine());
                }

                Console.WriteLine();
                recipe.DisplayRecipe();

                // Calculate and display the total calories of all the ingredients in the recipe
                int totalCalories = recipe.CalculateTotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");

                // Check if the total calories exceed 300 and notify the user if it does
                if (totalCalories > 300)
                {
                    Console.WriteLine("Attention: The total calories of this recipe exceed 300!");
                }

                recipes.Add(recipe);

                Console.WriteLine();
                Console.WriteLine("Enter 'continue' to add another recipe or 'display' to view the list of recipes:");
                string input = Console.ReadLine();

                if (input == "display")
                {
                    // Display the list of recipes in alphabetical order by name
                    recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));
                    Console.WriteLine("List of Recipes:");
                    foreach (Recipe r in recipes)
                    {
                        Console.WriteLine(r.Name);
                    }

                    Console.WriteLine("Enter the name of the recipe you want to display:");
                    string recipeName = Console.ReadLine();

                    // Find the recipe with the specified name and display it
                    Recipe selectedRecipe = recipes.Find(r => r.Name == recipeName);
                    if (selectedRecipe != null)
                    {
                        Console.WriteLine();
                        selectedRecipe.DisplayRecipe();
                    }
                    else
                    {
                        Console.WriteLine("Recipe not found.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Enter 'continue' to add another recipe or 'exit' to exit the program:");
                    input = Console.ReadLine();

                    if (input == "exit")
                    {
                        break;
                    }
                }
                else if (input == "exit")
                {
                    break;
                }
            }
        }
    }

    public class Recipe
    {
        // Properties to store the name, number of ingredients, ingredients, number of steps, and steps
        public string Name { get; set; }
        public int IngredientCount { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int StepCount { get; set; }
        public List<string> Steps { get; set; }

        // Default constructor to initialize collections
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Display the full recipe, including ingredients and steps
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name} - {ingredient.Calories} calories - {ingredient.FoodGroup}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < StepCount; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        // Calculate the total calories of all ingredients in the recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }

    public class Ingredient
    {
        // Properties to store the name, number of calories, and food group of an ingredient
        public string Name { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to set the name, number of calories, and food group
        public Ingredient(string name, int calories, string foodGroup)
        {
            Name = name;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

}
