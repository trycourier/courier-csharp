using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BulkCreateJobParams
{
    [JsonPropertyName("message")]
    public required InboundBulkMessage Message { get; init; }
}
