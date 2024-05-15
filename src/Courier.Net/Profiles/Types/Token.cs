using System.Text.Json.Serialization;

namespace Courier.Net;

public class Token
{
    [JsonPropertyName("token")]
    public string Token_ { get; init; }
}
