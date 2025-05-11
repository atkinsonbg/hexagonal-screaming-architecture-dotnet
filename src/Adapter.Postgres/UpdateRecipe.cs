using Core.Models;
using Core.UseCases;
using Npgsql;

namespace Adapter.Postgres;

public class UpdateRecipe : IUpdateRecipe
{
    public Recipe PerformUpdate(Recipe recipe)
    {
        
        using (var conn = new NpgsqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Update recipe
                    using (var cmd = new NpgsqlCommand(
                        @"UPDATE recipes 
                          SET title = @title, 
                              description = @description, 
                              instructions = @instructions,
                              updated_at = CURRENT_TIMESTAMP 
                          WHERE id = @id", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@id", recipe.Id);
                        cmd.Parameters.AddWithValue("@title", recipe.Title);
                        cmd.Parameters.AddWithValue("@description", recipe.Description);
                        cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                        
                        var rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            return null; // Recipe not found
                    }

                    // Delete existing ingredients
                    using (var cmd = new NpgsqlCommand(
                        "DELETE FROM ingredients WHERE recipe_id = @recipeId", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@recipeId", recipe.Id);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert updated ingredients
                    if (recipe.Ingredients?.Any() == true)
                    {
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            using (var cmd = new NpgsqlCommand(
                                @"INSERT INTO ingredients (recipe_id, name, amount) 
                                  VALUES (@recipeId, @name, @amount)", conn))
                            {
                                cmd.Transaction = transaction;
                                cmd.Parameters.AddWithValue("@recipeId", recipe.Id);
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
