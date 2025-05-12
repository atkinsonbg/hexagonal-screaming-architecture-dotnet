using Adapter.MinimalAPI;
using Microsoft.Extensions.DependencyInjection;

var api = new AdapterMinimalApi(args, services =>
{
    services.AddSingleton<Core.UseCases.IGetRecipe, Adapter.Postgres.GetRecipe>();
    services.AddSingleton<Core.UseCases.IDeleteRecipe, Adapter.Postgres.DeleteRecipe>();
    services.AddSingleton<Core.UseCases.IInsertRecipe, Adapter.Postgres.InsertRecipe>();
    services.AddSingleton<Core.UseCases.IUpdateRecipe, Adapter.Postgres.UpdateRecipe>();
});

await api.RunAsync();

public partial class Program {}