using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record ElementalContent
{
    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }

    [JsonPropertyName("brand")]
    public object? Brand { get; init; }

    [JsonPropertyName("elements")]
    public IEnumerable<object> Elements { get; init; } = new List<object>();
}
