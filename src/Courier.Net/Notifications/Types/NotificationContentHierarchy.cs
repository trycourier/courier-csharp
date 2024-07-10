using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record NotificationContentHierarchy
{
    [JsonPropertyName("parent")]
    public string? Parent { get; init; }

    [JsonPropertyName("children")]
    public string? Children { get; init; }
}
