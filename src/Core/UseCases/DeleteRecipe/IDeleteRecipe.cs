using Core.Models;

namespace Core.UseCases;

public interface IDeleteRecipe
{
    bool PerformDelete(int id);
}