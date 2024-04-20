using RecipesApplication.Interface;
using RecipesApplication.Models;

namespace RecipesApplication.HelperClasses;

public class SimpleCombinationGenerator : ICombinationGenerator
{
    private readonly IRecipeValidator _validator;
    public SimpleCombinationGenerator(IRecipeValidator validator)
    {
        _validator = validator;
    }

    public IEnumerable<int[]> GetCombinations(int numberOfRecipes, int maxQuantityPerRecipe)
    {
        List<int[]> combinations = new List<int[]>();
        int[] currentCombination = new int[numberOfRecipes];
        bool done = false;

        while (!done)
        {
            combinations.Add(currentCombination.ToArray());

            done = true; 
            for (int i = 0; i < numberOfRecipes; i++)
            {
                if (currentCombination[i] < maxQuantityPerRecipe)
                {
                    currentCombination[i]++;
                    done = false;
                    for (int j = 0; j < i; j++)
                    {
                        currentCombination[j] = 0;
                    }
                    break;
                }
            }
        }

        return combinations;
    }

    public Dictionary<string, int>? FindBestCombination(IEnumerable<int[]> allCombinations, List<Recipe> recipes, Dictionary<string, int> ingredients)
    {
        if (allCombinations == null || recipes == null || ingredients == null)
            return new Dictionary<string, int>();

        Dictionary<string, int>? bestCombination = null;
        int maxPeopleFed = 0, leastNumberOfRecipesUsed = int.MaxValue, leastTotalQuantityUsed = int.MaxValue;

        foreach (var combination in allCombinations)
        {
            var count = allCombinations.Count();
            var currentCombination = recipes.Select((r, i) => new { r.Name, Quantity = combination[i] })
            .ToDictionary(n => n.Name!, n => n.Quantity);

            if (_validator.IsValidCombination(currentCombination, recipes, ingredients))
            {
                int peopleFed = currentCombination.Sum(item => recipes.First(r => r.Name == item.Key).Feeds * item.Value);
                int numberOfRecipesUsed = currentCombination.Count(kv => kv.Value > 0);
                int totalQuantityUsed = currentCombination.Sum(kv => kv.Value);

                if (peopleFed > maxPeopleFed ||
                    (peopleFed == maxPeopleFed && (numberOfRecipesUsed < leastNumberOfRecipesUsed ||
                    (numberOfRecipesUsed == leastNumberOfRecipesUsed && totalQuantityUsed < leastTotalQuantityUsed))))
                {
                    maxPeopleFed = peopleFed;
                    leastNumberOfRecipesUsed = numberOfRecipesUsed;
                    leastTotalQuantityUsed = totalQuantityUsed;
                    bestCombination = new Dictionary<string, int>(currentCombination);
                }
            }
        }
        return bestCombination;
    }
}
