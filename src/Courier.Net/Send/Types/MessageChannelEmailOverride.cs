using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record MessageChannelEmailOverride
{
    [JsonPropertyName("attachments")]
    public IEnumerable<Dictionary<string, object>>? Attachments { get; init; }

    [JsonPropertyName("bcc")]
    public string? Bcc { get; init; }

    [JsonPropertyName("brand")]
    public Brand? Brand { get; init; }

    [JsonPropertyName("cc")]
    public string? Cc { get; init; }

    [JsonPropertyName("from")]
    public string? From { get; init; }

    [JsonPropertyName("html")]
    public string? Html { get; init; }

    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; init; }

    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("tracking")]
    public required TrackingOverride Tracking { get; init; }
}
