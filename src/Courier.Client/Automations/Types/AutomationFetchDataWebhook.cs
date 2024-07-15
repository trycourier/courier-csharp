using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AutomationFetchDataWebhook
{
    [JsonPropertyName("body")]
    public Dictionary<string, object>? Body { get; init; }

    [JsonPropertyName("headers")]
    public Dictionary<string, object>? Headers { get; init; }

    [JsonPropertyName("params")]
    public Dictionary<string, object>? Params { get; init; }

    [JsonPropertyName("method")]
    public required AutomationFetchDataWebhookMethod Method { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
