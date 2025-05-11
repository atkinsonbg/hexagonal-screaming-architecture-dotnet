using Core.Models;

namespace Core.UseCases;

public interface IUpdateRecipe
{
    Recipe PerformUpdate(Recipe recipe);
}