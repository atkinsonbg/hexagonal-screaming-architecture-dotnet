public static class GetRecipeEndpoint
{
    public static WebApplication MapGetRecipeEndpoint(this WebApplication app)
    {
        app.MapGet("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        var id = request.RouteValues["id"];
        return Results.Ok($"Recipe {id} retrieved");
    }
}