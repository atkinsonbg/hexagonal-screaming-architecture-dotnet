var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Force the ports to use
app.Urls.Add("http://localhost:5098");

app.MapGet("/", () => "Hello World!");

// add in our endpoints defined in our UseCases directory
app.MapGetRecipeEndpoint();
app.MapInsertRecipeEndpoint();
app.MapUpdateRecipeEndpoint();
app.MapDeleteRecipeEndpoint();

app.Run();
