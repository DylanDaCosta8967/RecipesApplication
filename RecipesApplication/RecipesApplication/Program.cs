using RecipesApplication.Data;
using RecipesApplication.HelperClasses;
using RecipesApplication.Interface;
using RecipesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var recipeManager = new RecipeData();
        var recipeValidator = new RecipeValidator();
        var Generator = new SimpleCombinationGenerator(new RecipeValidator());

        var recipes = recipeManager.GetRecipes();
        var ingredients = recipeManager.GetIngredients();

        var maxQuantityPerRecipe = recipeValidator.CalculateMaxPerRecipe(ingredients, recipes);
        var allCombinations = Generator.GetCombinations(recipes.Count, maxQuantityPerRecipe);

        var bestCombination = Generator.FindBestCombination(allCombinations, recipes, ingredients);
        if (bestCombination != null)
        {
            DisplayResults(bestCombination);
        }
    }

    private static void DisplayResults(Dictionary<string, int> bestCombination)
    {
        if (bestCombination == null)
        {
            Console.WriteLine("No valid combinations found.");
            return;
        }

        Console.WriteLine("Max People Fed with Fewest Recipes and Quantities:");
        foreach (var item in bestCombination)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}
