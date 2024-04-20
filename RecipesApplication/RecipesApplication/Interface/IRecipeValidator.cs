using RecipesApplication.Models;

namespace RecipesApplication.Interface;
public interface IRecipeValidator
{
    bool IsValidCombination(Dictionary<string, int> combination, IEnumerable<Recipe> recipes, IDictionary<string, int> availableIngredients);

    int CalculateMaxPerRecipe(Dictionary<string, int> ingredients, List<Recipe> recipes);
}

