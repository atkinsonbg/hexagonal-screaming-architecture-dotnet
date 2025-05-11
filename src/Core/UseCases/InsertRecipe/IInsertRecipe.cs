using Core.Models;

namespace Core.UseCases;

public interface IInsertRecipe
{
    Recipe PerformInsert(Recipe recipe);
}