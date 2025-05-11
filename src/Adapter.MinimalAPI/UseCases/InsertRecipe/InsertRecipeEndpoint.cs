using Core.UseCases;

public static class InsertRecipeEndpoint
{
    public static WebApplication MapInsertRecipeEndpoint(this WebApplication app)
    {
        app.MapPost("/recipe", async (Recipe recipe, IInsertRecipe iInsertRecipe) => await HandleAsync(recipe, iInsertRecipe));
        return app;
    }

    private static async Task<IResult> HandleAsync(Recipe recipe, IInsertRecipe iInsertRecipe)
    {
        var coreRecipe = new Core.Models.Recipe()
        {
            Title = recipe.Title,
            Description = recipe.Description,
            Instructions = recipe.Instructions,
            Ingredients = recipe.Ingredients.Select(i => new Core.Models.Ingredient
            {
                Name = i.Name,
                Amount = i.Amount
            }).ToList()
        };

        var insertRecipeUseCase = new Core.UseCases.InsertRecipe(iInsertRecipe);
        var insertRecipe = insertRecipeUseCase.PerformInsert(coreRecipe);
        
        InsertRecipeResponse response = new InsertRecipeResponse()
        {
            Id = insertRecipe.Id
        };
        
        return Results.Ok(response);
    }
}