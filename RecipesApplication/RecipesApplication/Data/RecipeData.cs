using RecipesApplication.Models;

namespace RecipesApplication.Data;
public class RecipeData
{
    public List<Recipe> GetRecipes()
    {
        return new List<Recipe>
        {
            new Recipe { Name = "Burger", Feeds = 1, Ingredients = new Dictionary<string, int> { { "Meat", 1 }, { "Lettuce", 1 }, { "Tomato", 1 }, { "Cheese", 1 }, { "Dough", 1 } } },
            new Recipe { Name = "Pasta", Feeds = 2, Ingredients = new Dictionary<string, int> { { "Dough", 2 }, { "Tomato", 1 }, { "Cheese", 2 }, { "Meat", 1 } } },
            new Recipe { Name = "Pie", Feeds = 1, Ingredients = new Dictionary<string, int> { { "Dough", 2 }, { "Meat", 2 } } },
            new Recipe { Name = "Salad", Feeds = 3, Ingredients = new Dictionary<string, int> { { "Lettuce", 2 }, { "Tomato", 2 }, { "Cucumber", 1 }, { "Cheese", 2 }, { "Olives", 1 } } },
            new Recipe { Name = "Sandwich", Feeds = 1, Ingredients = new Dictionary<string, int> { { "Dough", 1 }, { "Cucumber", 1 } } },
            new Recipe { Name = "Pizza", Feeds = 4, Ingredients = new Dictionary<string, int> { { "Dough", 3 }, { "Tomato", 2 }, { "Cheese", 3 }, { "Olives", 1 } } }
        };
    }

    public Dictionary<string, int> GetIngredients()
    {
        return new Dictionary<string, int>
        {
            { "Cucumber", 2 },
            { "Olives", 2 },
            { "Lettuce", 3 },
            { "Meat", 6 },
            { "Tomato", 6 },
            { "Cheese", 8 },
            { "Dough", 10 }
        };
    }
}