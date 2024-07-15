using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BulkCreateJobParams
{
    [JsonPropertyName("message")]
    public required InboundBulkMessage Message { get; init; }
}
