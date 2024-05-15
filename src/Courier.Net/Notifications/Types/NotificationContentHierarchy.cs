using System.Text.Json.Serialization;

namespace Courier.Net;

public class NotificationContentHierarchy
{
    [JsonPropertyName("parent")]
    public string? Parent { get; init; }

    [JsonPropertyName("children")]
    public string? Children { get; init; }
}
