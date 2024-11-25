using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record InboundBulkMessage
{
    [JsonPropertyName("message")]
    public OneOf<InboundBulkTemplateMessage, InboundBulkContentMessage>? Message { get; set; }

    /// <summary>
    /// A unique identifier that represents the brand that should be used
    /// for rendering the notification.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// JSON that includes any data you want to pass to a message template.
    /// The data will populate the corresponding template variables.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    [JsonPropertyName("event")]
    public string? Event { get; set; }

    [JsonPropertyName("locale")]
    public Dictionary<string, object?>? Locale { get; set; }

    /// <summary>
    /// JSON that is merged into the request sent by Courier to the provider
    /// to override properties or to gain access to features in the provider
    /// API that are not natively supported by Courier.
    /// </summary>
    [JsonPropertyName("override")]
    public object? Override { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
