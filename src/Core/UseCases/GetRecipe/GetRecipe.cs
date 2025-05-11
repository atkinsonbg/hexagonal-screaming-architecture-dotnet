using Core.Models;

namespace Core.UseCases;

public class GetRecipe
{
    private readonly IGetRecipe _getRecipe;

    public GetRecipe(IGetRecipe getRecipe)
    {
        _getRecipe = getRecipe;
    }

    public Recipe? PerformGet(int id)
    {
        return _getRecipe.PerformGet(id);
    }
}