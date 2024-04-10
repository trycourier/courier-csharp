using System.Text.Json.Serialization;

namespace Courier.Net;

public class AirshipProfileAudience
{
    [JsonPropertyName("named_user")]
    public string NamedUser { get; init; }
}
