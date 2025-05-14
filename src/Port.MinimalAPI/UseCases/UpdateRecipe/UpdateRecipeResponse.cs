using System.Text.Json.Serialization;

public record UpdateRecipeResponse : Recipe
{
    [JsonPropertyNameAttribute("id")] public int Id { get; init; }
}