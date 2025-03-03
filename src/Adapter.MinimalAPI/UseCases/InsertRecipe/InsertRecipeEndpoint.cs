public static class InsertRecipeEndpoint
{
    public static WebApplication MapInsertRecipeEndpoint(this WebApplication app)
    {
        app.MapPost("/recipe", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        InsertRecipeResponse response = new InsertRecipeResponse()
        {
            Id = 1
        };
        
        return Results.Ok(response);
    }
}