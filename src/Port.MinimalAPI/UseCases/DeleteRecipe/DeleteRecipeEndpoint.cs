using Core.UseCases;

public static class DeleteRecipeEndpoint
{
    public static WebApplication MapDeleteRecipeEndpoint(this WebApplication app)
    {
        app.MapDelete("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request, Core.UseCases.IDeleteRecipe iDeleteRecipe)
    {
        int id = int.Parse(request?.RouteValues?["id"].ToString());
        var successfullyDeletedRecipe = new Core.UseCases.DeleteRecipe(iDeleteRecipe).PerformDelete(id);

        DeleteRecipeResponse response = new DeleteRecipeResponse()
        {
            Id = id,
            Success = successfullyDeletedRecipe,
            Message = successfullyDeletedRecipe 
                ? $"Successfully deleted recipe with ID: {id}" 
                : $"Failed to delete recipe with ID: {id}"
        };
        
        return Results.Ok(response);
    }
}