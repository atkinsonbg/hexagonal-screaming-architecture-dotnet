using System.Text.Json.Serialization;

public record InsertRecipeResponse : Recipe
{
    [JsonPropertyNameAttribute("id")] public int Id { get; init; }
}