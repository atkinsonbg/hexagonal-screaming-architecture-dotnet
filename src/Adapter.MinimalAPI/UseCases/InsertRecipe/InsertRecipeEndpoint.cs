public static class InsertRecipeEndpoint
{
    public static WebApplication MapInsertRecipeEndpoint(this WebApplication app)
    {
        app.MapPost("/recipe", HandleAsync);
        return app;
    }

    private static IResult HandleAsync()
    {
        return Results.Ok("Recipe inserted");
    }
}