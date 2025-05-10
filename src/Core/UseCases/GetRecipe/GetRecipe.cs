using Core.Models;

namespace Core.UseCases;

public class GetRecipe
{
    public GetRecipe()
    {
        // Constructor logic if needed
    }

    public Recipe? PerformGet(int id)
    {
        // Simulate fetching the recipe
        // In a real application, this would involve database operations
        // For this example, we'll just return the recipe back
        if (id == 1)
        {
            return new Recipe
            {
                Id = 1,
                Title = "Spaghetti Bolognese",
                Description = "A classic Italian pasta dish with a rich meat sauce.",
                Ingredients = new List<Ingredient> 
                {
                    new Ingredient { Name = "Spaghetti", Amount = "200g" },
                    new Ingredient { Name = "Ground Beef", Amount = "300g" },
                    new Ingredient { Name = "Tomato Sauce", Amount = "400ml" },
                    new Ingredient { Name = "Onion", Amount = "1, chopped" },
                    new Ingredient { Name = "Garlic", Amount = "2 cloves, minced" },
                    new Ingredient { Name = "Olive Oil", Amount = "2 tbsp" },
                    new Ingredient { Name = "Salt", Amount = "to taste" },
                    new Ingredient { Name = "Pepper", Amount = "to taste" }
                },
            };
        }
        return null;
    }
}