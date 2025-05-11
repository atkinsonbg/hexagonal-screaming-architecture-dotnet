using Core.Models;

namespace Core.UseCases;

public interface IGetRecipe
{
    Recipe PerformGet(int id);
}