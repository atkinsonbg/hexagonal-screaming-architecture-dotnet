using Core.Models;

namespace Core.UseCases;

public class InsertRecipe
{
    private readonly IInsertRecipe _insertRecipe;

    public InsertRecipe(IInsertRecipe insertRecipe)
    {
        _insertRecipe = insertRecipe;
    }

    public Recipe PerformInsert(Recipe recipe)
    {
        return _insertRecipe.PerformInsert(recipe);
    }
}