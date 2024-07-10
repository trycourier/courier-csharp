using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BulkCreateJobParams
{
    [JsonPropertyName("message")]
    public required InboundBulkMessage Message { get; init; }
}
