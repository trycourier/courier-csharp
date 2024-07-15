using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BrandSettings
{
    [JsonPropertyName("colors")]
    public BrandColors? Colors { get; init; }

    [JsonPropertyName("inapp")]
    public object? Inapp { get; init; }

    [JsonPropertyName("email")]
    public Email? Email { get; init; }
}
