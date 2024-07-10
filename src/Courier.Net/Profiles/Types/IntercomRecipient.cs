using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record IntercomRecipient
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
