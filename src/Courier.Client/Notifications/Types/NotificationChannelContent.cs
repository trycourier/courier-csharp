using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record NotificationChannelContent
{
    [JsonPropertyName("subject")]
    public string? Subject { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }
}
