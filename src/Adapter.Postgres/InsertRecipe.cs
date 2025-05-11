using Core.Models;
using Core.UseCases;
using Npgsql;

namespace Adapter.Postgres;

public class InsertRecipe : IInsertRecipe
{
    public Recipe PerformInsert(Recipe recipe)
    {
        
        using (var conn = new NpgsqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Insert recipe first to get the ID
                    int recipeId;
                    using (var cmd = new NpgsqlCommand(
                        "INSERT INTO recipes (title, description, instructions) VALUES (@title, @description, @instructions) RETURNING id", 
                        conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@title", recipe.Title);
                        cmd.Parameters.AddWithValue("@description", recipe.Description);
                        cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                        
                        recipeId = (int)cmd.ExecuteScalar();
                        recipe.Id = recipeId;
                    }

                    // Insert ingredients
                    if (recipe.Ingredients?.Any() == true)
                    {
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            using (var cmd = new NpgsqlCommand(
                                "INSERT INTO ingredients (recipe_id, name, amount) VALUES (@recipeId, @name, @amount)", 
                                conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("@recipeId", recipeId);
                                cmd.Parameters.AddWithValue("@name", ingredient.Name);
                                cmd.Parameters.AddWithValue("@amount", ingredient.Amount);
                                
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    return recipe;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
