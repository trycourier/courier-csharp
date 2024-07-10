using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record NotificationChannelContent
{
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }
}
