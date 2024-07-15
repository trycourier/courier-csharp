using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record IntercomRecipient
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
