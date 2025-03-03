using System.Text.Json.Serialization;

public record GetRecipeResponse : Recipe
{
    [JsonPropertyNameAttribute("id")] public int Id { get; init; }
}