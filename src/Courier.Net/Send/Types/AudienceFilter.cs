using System.Text.Json.Serialization;

namespace Courier.Net;

public class AudienceFilter
{
    /// <summary>
    /// Send to users only if they are member of the account
    /// </summary>
    [JsonPropertyName("operator")]
    public string Operator { get; init; }

    [JsonPropertyName("path")]
    public string Path { get; init; }

    [JsonPropertyName("value")]
    public string Value { get; init; }
}
