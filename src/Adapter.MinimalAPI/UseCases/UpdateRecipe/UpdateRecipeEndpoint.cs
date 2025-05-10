public static class UpdateRecipeEndpoint
{
    public static WebApplication MapUpdateRecipeEndpoint(this WebApplication app)
    {
        app.MapPut("/recipe", async (Recipe recipe) => await HandleAsync(recipe));
        return app;
    }

    private static async Task<IResult> HandleAsync(Recipe recipe)
    {
        var coreRecipe = new Core.Models.Recipe()
        {
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => new Core.Models.Ingredient
            {
                Name = i.Name,
                Amount = i.Amount
            }).ToList()
        };

        var coreUpdateRecipe = new Core.UseCases.UpdateRecipe();
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