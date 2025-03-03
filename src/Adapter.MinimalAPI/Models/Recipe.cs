using System.Text.Json.Serialization;

public record Recipe
{
    [JsonPropertyNameAttribute("title")] public string Title { get; init; }
    [JsonPropertyNameAttribute("description")] public string Description { get; init; }
    [JsonPropertyNameAttribute("instructions")] public string Instructions { get; init; }
    [JsonPropertyNameAttribute("ingredients")] public List<Ingredient> Ingredients { get; init; }
}

public record Ingredient
{
    [JsonPropertyNameAttribute("name")] public string Name { get; init; }
    [JsonPropertyName("amount")] public string Amount { get; init; }
}