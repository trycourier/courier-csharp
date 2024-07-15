using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record List
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("created")]
    public int? Created { get; init; }

    [JsonPropertyName("updated")]
    public int? Updated { get; init; }
}
