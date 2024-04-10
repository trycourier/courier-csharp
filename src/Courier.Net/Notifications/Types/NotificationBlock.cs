using System.Text.Json.Serialization;
using Courier.Net;
using OneOf;

namespace Courier.Net;

public class NotificationBlock
{
    [JsonPropertyName("alias")]
    public string? Alias { get; init; }

    [JsonPropertyName("context")]
    public string? Context { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("type")]
    public BlockType Type { get; init; }

    [JsonPropertyName("content")]
    public OneOf<string, NotificationContentHierarchy>? Content { get; init; }

    [JsonPropertyName("locales")]
    public Dictionary<string, OneOf<string, NotificationContentHierarchy>>? Locales { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
