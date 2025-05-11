namespace Core.UseCases;

public class DeleteRecipe
{
    private readonly IDeleteRecipe _deleteRecipe;
    
    public DeleteRecipe(IDeleteRecipe deleteRecipe)
    {
        _deleteRecipe = deleteRecipe;
    }

    public bool PerformDelete(int id)
    {
        return _deleteRecipe.PerformDelete(id);
    }
}