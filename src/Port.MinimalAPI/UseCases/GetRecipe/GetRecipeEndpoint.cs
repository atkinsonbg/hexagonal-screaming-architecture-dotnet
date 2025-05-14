public static class GetRecipeEndpoint
{
    public static WebApplication MapGetRecipeEndpoint(this WebApplication app)
    {
        app.MapGet("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        string id = request.RouteValues["id"].ToString();

        GetRecipeResponse response = new GetRecipeResponse()
        {
            Id = int.Parse(id)
        };
        
        return Results.Ok(response);
    }
}