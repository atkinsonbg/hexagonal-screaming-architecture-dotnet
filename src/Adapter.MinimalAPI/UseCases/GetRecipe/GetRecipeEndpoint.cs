public static class GetRecipeEndpoint
{
    public static WebApplication MapGetRecipeEndpoint(this WebApplication app)
    {
        app.MapGet("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        int id = int.Parse(request?.RouteValues["id"]?.ToString());

        var recipe = new Core.UseCases.GetRecipe().PerformGet(id);
        
        if (recipe == null)
        {
            return Results.NotFound();
        }

        GetRecipeResponse response = new GetRecipeResponse()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients.Select(i => new Ingredient
            {
                Name = i.Name,
                Amount = i.Amount
            }).ToList()
        };
        
        return Results.Ok(response);
    }
}