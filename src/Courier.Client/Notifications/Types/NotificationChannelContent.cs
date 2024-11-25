using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationChannelContent
{
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
