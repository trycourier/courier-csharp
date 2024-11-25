using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationFetchDataWebhook
{
    [JsonPropertyName("body")]
    public Dictionary<string, object?>? Body { get; set; }

    [JsonPropertyName("headers")]
    public Dictionary<string, object?>? Headers { get; set; }

    [JsonPropertyName("params")]
    public Dictionary<string, object?>? Params { get; set; }

    [JsonPropertyName("method")]
    public required AutomationFetchDataWebhookMethod Method { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
