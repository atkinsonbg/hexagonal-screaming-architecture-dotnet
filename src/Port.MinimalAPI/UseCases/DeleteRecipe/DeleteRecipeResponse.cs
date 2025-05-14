using System.Text.Json.Serialization;

public record DeleteRecipeResponse
{
    [JsonPropertyNameAttribute("id")] public int Id { get; init; }

    [JsonPropertyNameAttribute("success")] public bool Success { get; init; }

    [JsonPropertyNameAttribute("message")] public string Message { get; init; }
}