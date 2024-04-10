using System.Text.Json.Serialization;

namespace Courier.Net;

public class SlackBaseProperties
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
}
