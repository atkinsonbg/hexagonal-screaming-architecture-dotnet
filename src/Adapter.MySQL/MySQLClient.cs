using Core.Models;
using Core.UseCases;
using MySql.Data.MySqlClient;

namespace Adapter.MySQL;

public class RecipeCRUD : IGetRecipe, IInsertRecipe, IUpdateRecipe, IDeleteRecipe
{
    public bool PerformDelete(int id)
    {
        using (var conn = new MySqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Delete ingredients first due to foreign key constraint
                    using (var cmd = new MySqlCommand("DELETE FROM ingredients WHERE recipe_id = @id", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Then delete the recipe
                    using (var cmd = new MySqlCommand("DELETE FROM recipes WHERE id = @id", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@id", id);
                        var rowsAffected = cmd.ExecuteNonQuery();
                        
                        transaction.Commit();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }

    public Recipe PerformGet(int id)
    {
        Recipe recipe = null;
    
        using (var conn = new MySqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            var sql = @"
                SELECT r.id, r.title, r.description, r.instructions, 
                    i.name, i.amount
                FROM recipes r
                LEFT JOIN ingredients i ON r.id = i.recipe_id
                WHERE r.id = @id";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (recipe == null)
                        {
                            recipe = new Recipe
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Description = reader.GetString(2),
                                Instructions = reader.GetString(3),
                                Ingredients = new List<Ingredient>()
                            };
                        }

                        if (!reader.IsDBNull(4)) // Check if there are ingredients
                        {
                            recipe.Ingredients.Add(new Ingredient
                            {
                                Name = reader.GetString(4),
                                Amount = reader.GetString(5)
                            });
                        }
                    }
                }
            }
        }
        
        return recipe;
    }

    public Recipe PerformInsert(Recipe recipe)
    {
        using (var conn = new MySqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Insert recipe first to get the ID
                    int recipeId;
                    using (var cmd = new MySqlCommand(
                        @"INSERT INTO recipes (title, description, instructions) 
                        VALUES (@title, @description, @instructions); 
                        SELECT LAST_INSERT_ID();", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@title", recipe.Title);
                        cmd.Parameters.AddWithValue("@description", recipe.Description);
                        cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                        
                        recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                        recipe.Id = recipeId;
                    }

                    // Insert ingredients
                    if (recipe.Ingredients?.Any() == true)
                    {
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            using (var cmd = new MySqlCommand(
                                @"INSERT INTO ingredients (recipe_id, name, amount) 
                                VALUES (@recipeId, @name, @amount)", conn))
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

    public Recipe PerformUpdate(Recipe recipe)
    {
        using (var conn = new MySqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Update recipe
                    using (var cmd = new MySqlCommand(
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
                    using (var cmd = new MySqlCommand(
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
                            using (var cmd = new MySqlCommand(
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
