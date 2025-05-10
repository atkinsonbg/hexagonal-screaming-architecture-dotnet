namespace Core.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Instructions { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}

public class Ingredient
{
    public string Name { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;
}