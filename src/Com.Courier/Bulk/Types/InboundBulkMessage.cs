using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record InboundBulkMessage
{
    [JsonPropertyName("message")]
    [JsonConverter(
        typeof(OneOfSerializer<OneOf<InboundBulkTemplateMessage, InboundBulkContentMessage>>)
    )]
    public OneOf<InboundBulkTemplateMessage, InboundBulkContentMessage>? Message { get; init; }

    /// <summary>
    /// A unique identifier that represents the brand that should be used
    /// for rendering the notification.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; init; }

    /// <summary>
    /// JSON that includes any data you want to pass to a message template.
    /// The data will populate the corresponding template variables.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object>? Data { get; init; }

    [JsonPropertyName("event")]
    public string? Event { get; init; }

    [JsonPropertyName("locale")]
    public Dictionary<string, object>? Locale { get; init; }

    /// <summary>
    /// JSON that is merged into the request sent by Courier to the provider
    /// to override properties or to gain access to features in the provider
    /// API that are not natively supported by Courier.
    /// </summary>
    [JsonPropertyName("override")]
    public object? Override { get; init; }
}
