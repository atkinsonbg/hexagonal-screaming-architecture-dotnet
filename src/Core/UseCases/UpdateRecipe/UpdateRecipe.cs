using Core.Models;

namespace Core.UseCases;

public class UpdateRecipe
{
    private readonly IUpdateRecipe _updateRecipe;

    public UpdateRecipe(IUpdateRecipe updateRecipe)
    {
        _updateRecipe = updateRecipe;
    }

    public Recipe PerformUpdate(Recipe recipe)
    {
        return _updateRecipe.PerformUpdate(recipe);
    }
}