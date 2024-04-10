using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class BrandSettings
{
    [JsonPropertyName("colors")]
    public BrandColors? Colors { get; init; }

    [JsonPropertyName("inapp")]
    public object? Inapp { get; init; }

    [JsonPropertyName("email")]
    public Email? Email { get; init; }
}
