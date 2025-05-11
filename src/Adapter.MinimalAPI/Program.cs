using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Core.UseCases.IGetRecipe, Adapter.Postgres.GetRecipe>();
builder.Services.AddSingleton<Core.UseCases.IDeleteRecipe, Adapter.Postgres.DeleteRecipe>();
builder.Services.AddSingleton<Core.UseCases.IInsertRecipe, Adapter.Postgres.InsertRecipe>();
builder.Services.AddSingleton<Core.UseCases.IUpdateRecipe, Adapter.Postgres.UpdateRecipe>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// add in our endpoints defined in our UseCases directory
app.MapGetRecipeEndpoint();
app.MapInsertRecipeEndpoint();
app.MapUpdateRecipeEndpoint();
app.MapDeleteRecipeEndpoint();

app.Run();
