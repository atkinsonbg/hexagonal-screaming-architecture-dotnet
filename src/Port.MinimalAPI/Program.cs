namespace Adapter.MinimalAPI;

public class AdapterMinimalApi
{
    private readonly WebApplication _app;

    public AdapterMinimalApi(string[] args, Action<IServiceCollection> services)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container, passed in via the ApplicationHost project
        services.Invoke(builder.Services);

        _app = builder.Build();

        // Force the ports to use
        _app.Urls.Add("http://localhost:5098");

        // Add the Hello World endpoint, that acts as a health check
        _app.MapGet("/", () => "Hello World!");

        // add in our endpoints defined in our UseCases directory
        _app.MapGetRecipeEndpoint();
        _app.MapInsertRecipeEndpoint();
        _app.MapUpdateRecipeEndpoint();
        _app.MapDeleteRecipeEndpoint();
    }

    public Task RunAsync()
    {
        return _app.RunAsync();
    }
}
