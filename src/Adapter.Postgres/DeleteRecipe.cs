using Core.UseCases;
using Npgsql;

namespace Adapter.Postgres;

public class DeleteRecipe : IDeleteRecipe
{
    public bool PerformDelete(int id)
    {
        
        using (var conn = new NpgsqlConnection(Constants.ConnectionString))
        {
            conn.Open();
            
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Delete ingredients first due to foreign key constraint
                    using (var cmd = new NpgsqlCommand("DELETE FROM ingredients WHERE recipe_id = @id", conn))
                    {
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Then delete the recipe
                    using (var cmd = new NpgsqlCommand("DELETE FROM recipes WHERE id = @id", conn))
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
}
