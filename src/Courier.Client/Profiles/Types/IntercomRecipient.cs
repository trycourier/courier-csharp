using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record IntercomRecipient
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
