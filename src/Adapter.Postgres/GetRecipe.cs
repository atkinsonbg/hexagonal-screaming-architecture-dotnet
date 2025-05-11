using Core.Models;
using Core.UseCases;
using Npgsql;

namespace Adapter.Postgres;

public class GetRecipe : IGetRecipe
{
    public Recipe PerformGet(int id)
    {
        var recipe = new Recipe();
        
        using (var conn = new NpgsqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            // Get recipe details
            using (var cmd = new NpgsqlCommand("SELECT id, title, description, instructions FROM recipes WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recipe.Id = reader.GetInt32(0);
                        recipe.Title = reader.GetString(1);
                        recipe.Description = reader.GetString(2);
                        recipe.Instructions = reader.GetString(3);
                    }
                    else
                    {
                        return null; // Or throw a custom exception
                    }
                }
            }
            
            // Get ingredients for the recipe
            using (var cmd = new NpgsqlCommand("SELECT name, amount FROM ingredients WHERE recipe_id = @recipe_id", conn))
            {
                cmd.Parameters.AddWithValue("@recipe_id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        recipe.Ingredients.Add(new Ingredient
                        {
                            Name = reader.GetString(0),
                            Amount = reader.GetString(1)
                        });
                    }
                }
            }
        }
        
        return recipe;
    }
}
