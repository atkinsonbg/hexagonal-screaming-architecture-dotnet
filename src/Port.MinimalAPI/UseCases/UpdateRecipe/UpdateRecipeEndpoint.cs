public static class UpdateRecipeEndpoint
{
    public static WebApplication MapUpdateRecipeEndpoint(this WebApplication app)
    {
        app.MapPut("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        string id = request.RouteValues["id"].ToString();

        UpdateRecipeResponse response = new UpdateRecipeResponse()
        {
            Id = int.Parse(id)
        };
        
        return Results.Ok(response);
    }
}