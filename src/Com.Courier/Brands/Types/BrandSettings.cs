using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BrandSettings
{
    [JsonPropertyName("colors")]
    public BrandColors? Colors { get; init; }

    [JsonPropertyName("inapp")]
    public object? Inapp { get; init; }

    [JsonPropertyName("email")]
    public Email? Email { get; init; }
}
