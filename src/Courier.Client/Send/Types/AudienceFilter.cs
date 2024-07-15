using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AudienceFilter
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
