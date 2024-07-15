using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record ListFilter
{
    /// <summary>
    /// Send to users only if they are member of the account
    /// </summary>
    [JsonPropertyName("operator")]
    public required string Operator { get; init; }

    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("value")]
    public required string Value { get; init; }
}
