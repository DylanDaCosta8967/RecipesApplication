namespace RecipesApplication.Models;
public class Recipe
{
    public string? Name { get; set; }
    public int Feeds { get; set; }
    public Dictionary<string, int>? Ingredients { get; set; }
}
