public record Recipe
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Instructions { get; init; } = string.Empty;
    public List<Ingredient> Ingredients { get; init; } = new List<Ingredient>();
}

public record Ingredient
{
    public string Name { get; init; } = string.Empty;
    public string Amount { get; init; } = string.Empty;
}