using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record NotificationBlock
{
    [JsonPropertyName("alias")]
    public string? Alias { get; set; }

    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required BlockType Type { get; set; }

    [JsonPropertyName("content")]
    public OneOf<string, NotificationContentHierarchy>? Content { get; set; }

    [JsonPropertyName("locales")]
    public Dictionary<string, OneOf<string, NotificationContentHierarchy>>? Locales { get; set; }

    [JsonPropertyName("checksum")]
    public string? Checksum { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
