public static class UpdateRecipeEndpoint
{
    public static WebApplication MapUpdateRecipeEndpoint(this WebApplication app)
    {
        app.MapPut("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        var id = request.RouteValues["id"];
        return Results.Ok($"Recipe {id} updated");
    }
}