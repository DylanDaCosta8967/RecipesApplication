namespace RecipesApplication.Interface;

public interface ICombinationGenerator
{
    IEnumerable<int[]> GetCombinations(int numberOfRecipes, int maxQuantityPerRecipe);
}
