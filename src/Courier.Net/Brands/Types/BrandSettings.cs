using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BrandSettings
{
    [JsonPropertyName("colors")]
    public BrandColors? Colors { get; init; }

    [JsonPropertyName("inapp")]
    public object? Inapp { get; init; }

    [JsonPropertyName("email")]
    public Email? Email { get; init; }
}
