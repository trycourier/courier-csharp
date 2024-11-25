using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record WebhookRecipient
{
    [JsonPropertyName("webhook")]
    public required WebhookProfile Webhook { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
