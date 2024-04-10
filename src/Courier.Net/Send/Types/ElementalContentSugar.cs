using System.Text.Json.Serialization;

namespace Courier.Net;

public class ElementalContentSugar
{
    /// <summary>
    /// The title to be displayed by supported channels i.e. push, email (as subject)
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    [JsonPropertyName("body")]
    public string Body { get; init; }
}
