using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record ElementalContentSugar
{
    /// <summary>
    /// The title to be displayed by supported channels i.e. push, email (as subject)
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; init; }
}
