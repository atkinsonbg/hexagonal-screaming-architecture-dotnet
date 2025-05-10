public static class InsertRecipeEndpoint
{
    public static WebApplication MapInsertRecipeEndpoint(this WebApplication app)
    {
        app.MapPost("/recipe", async (Recipe recipe) => await HandleAsync(recipe));
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

        var insertRecipeUseCase = new Core.UseCases.InsertRecipe();
        var insertRecipe = insertRecipeUseCase.PerformInsert(coreRecipe);
        
        InsertRecipeResponse response = new InsertRecipeResponse()
        {
            Id = insertRecipe.Id
        };
        
        return Results.Ok(response);
    }
}