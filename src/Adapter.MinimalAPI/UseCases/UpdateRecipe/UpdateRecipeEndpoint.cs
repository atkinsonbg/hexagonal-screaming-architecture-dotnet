using Core.UseCases;

public static class UpdateRecipeEndpoint
{
    public static WebApplication MapUpdateRecipeEndpoint(this WebApplication app)
    {
        app.MapPut("/recipe", async (Recipe recipe, IUpdateRecipe iUpdateRecipe) => await HandleAsync(recipe, iUpdateRecipe));
        return app;
    }

    private static async Task<IResult> HandleAsync(Recipe recipe, IUpdateRecipe iUpdateRecipe)
    {
        var coreRecipe = new Core.Models.Recipe()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Instructions = recipe.Instructions,
            Ingredients = recipe.Ingredients.Select(i => new Core.Models.Ingredient
            {
                Name = i.Name,
                Amount = i.Amount
            }).ToList()
        };

        var coreUpdateRecipe = new Core.UseCases.UpdateRecipe(iUpdateRecipe);
        var updatedRecipe = coreUpdateRecipe.PerformUpdate(coreRecipe);

        UpdateRecipeResponse response = new UpdateRecipeResponse()
        {
            Id = updatedRecipe.Id,
            Title = updatedRecipe.Title,
            Description = updatedRecipe.Description
        };
        
        return Results.Ok(response);
    }
}