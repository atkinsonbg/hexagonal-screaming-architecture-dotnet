using System.Text.Json.Serialization;

public record Recipe
{
    [JsonPropertyNameAttribute("id")] public int Id { get; init; }
    [JsonPropertyNameAttribute("title")] public string Title { get; init; } = string.Empty;
    [JsonPropertyNameAttribute("description")] public string Description { get; init; } = string.Empty;
    [JsonPropertyNameAttribute("instructions")] public string Instructions { get; init; } = string.Empty;
    [JsonPropertyNameAttribute("ingredients")] public List<Ingredient> Ingredients { get; init; } = new List<Ingredient>();
}

public record Ingredient
{
    [JsonPropertyNameAttribute("name")] public string Name { get; init; } = string.Empty;
    [JsonPropertyName("amount")] public string Amount { get; init; } = string.Empty;
}