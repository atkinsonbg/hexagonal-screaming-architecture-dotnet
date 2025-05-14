public static class DeleteRecipeEndpoint
{
    public static WebApplication MapDeleteRecipeEndpoint(this WebApplication app)
    {
        app.MapDelete("/recipe/{id}", HandleAsync);
        return app;
    }

    private static IResult HandleAsync(HttpRequest request)
    {
        string id = request.RouteValues["id"].ToString();

        DeleteRecipeResponse response = new DeleteRecipeResponse()
        {
            Id = int.Parse(id),
            Success = true,
            Message = $"Successfully deleted recipe with ID: {id}"
        };
        
        return Results.Ok(response);
    }
}