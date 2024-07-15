using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record NotificationBlock
{
    [JsonPropertyName("alias")]
    public string? Alias { get; init; }

    [JsonPropertyName("context")]
    public string? Context { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("type")]
    public required BlockType Type { get; init; }

    [JsonPropertyName("content")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<string, NotificationContentHierarchy>>))]
    public OneOf<string, NotificationContentHierarchy>? Content { get; init; }

    [JsonPropertyName("locales")]
    public Dictionary<string, OneOf<string, NotificationContentHierarchy>>? Locales { get; init; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; init; }
}
