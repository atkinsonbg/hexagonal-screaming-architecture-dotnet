using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Core.UseCases.IGetRecipe, Adapter.Postgres.GetRecipe>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// add in our endpoints defined in our UseCases directory
app.MapGetRecipeEndpoint();
app.MapInsertRecipeEndpoint();
app.MapUpdateRecipeEndpoint();
app.MapDeleteRecipeEndpoint();

app.Run();
