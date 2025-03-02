using System.Text.Json.Serialization;

public record Recipe
{
    [JsonPropertyNameAttribute("title")] public string Title;
    [JsonPropertyNameAttribute("description")] public string Description;
    [JsonPropertyNameAttribute("instructions")] public string Instructions;
    [JsonPropertyNameAttribute("ingredients")] public List<Ingredient> Ingredients;
}

public record Ingredient
{
    [JsonPropertyNameAttribute("name")] public string Name;
    [JsonPropertyName("amount")] public string Amount;
}