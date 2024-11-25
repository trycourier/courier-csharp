using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalContentSugar
{
    /// <summary>
    /// The title to be displayed by supported channels i.e. push, email (as subject)
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
