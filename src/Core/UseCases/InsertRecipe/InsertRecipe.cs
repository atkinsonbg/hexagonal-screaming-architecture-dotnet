using Core.Models;

namespace Core.UseCases;

public class InsertRecipe
{
    public InsertRecipe()
    {
        // Constructor logic if needed
    }

    public Recipe PerformInsert(Recipe recipe)
    {
        // Simulate inserting the recipe
        // In a real application, this would involve database operations, and returning a status code
        // For this example, we'll just return the recipe back with a new ID
        recipe.Id = 2;
        return recipe;
    }
}