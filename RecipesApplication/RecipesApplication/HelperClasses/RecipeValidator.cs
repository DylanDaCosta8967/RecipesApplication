using RecipesApplication.Interface;
using RecipesApplication.Models;

namespace RecipesApplication.HelperClasses;
public class RecipeValidator : IRecipeValidator
{
    public bool IsValidCombination(Dictionary<string, int> combination, IEnumerable<Recipe> recipes, IDictionary<string, int> availableIngredients)
    {
        if (combination == null || recipes == null || availableIngredients == null)
            return false;

        var requiredIngredients = new Dictionary<string, int>();
        foreach (var pair in combination)
        {
            var recipe = recipes.First(r => r.Name == pair.Key);
            if (recipe.Ingredients != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (!requiredIngredients.ContainsKey(ingredient.Key))
                        requiredIngredients[ingredient.Key] = 0;
                    requiredIngredients[ingredient.Key] += ingredient.Value * pair.Value;
                }
            }
        }
        return requiredIngredients.All(req => availableIngredients.ContainsKey(req.Key) && availableIngredients[req.Key] >= req.Value);
    }

    public int CalculateMaxPerRecipe(Dictionary<string, int> ingredients, List<Recipe> recipes)
    {
        var maxPerRecipe = new List<int>();
        int highestMaxPossible = 0;
        foreach (var recipe in recipes)
        {
            int maxPossible = int.MaxValue;
            if (recipe.Ingredients != null)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredients.ContainsKey(ingredient.Key))
                    {
                        if (ingredients[ingredient.Key] / ingredient.Value < maxPossible)
                        {
                            maxPossible = ingredients[ingredient.Key] / ingredient.Value;
                        }
                    }
                    else
                    {
                        maxPossible = 0;
                        break;
                    }
                }
            }
            maxPerRecipe.Add(maxPossible);

            if (maxPossible > highestMaxPossible)
            {
                highestMaxPossible = maxPossible;
            }
        }
        return highestMaxPossible;
    }
}
