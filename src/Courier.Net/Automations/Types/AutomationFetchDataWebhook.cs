using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AutomationFetchDataWebhook
{
    [JsonPropertyName("body")]
    public Dictionary<string, object>? Body { get; init; }

    [JsonPropertyName("headers")]
    public Dictionary<string, object>? Headers { get; init; }

    [JsonPropertyName("params")]
    public Dictionary<string, object>? Params { get; init; }

    [JsonPropertyName("method")]
    public AutomationFetchDataWebhookMethod Method { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }
}
