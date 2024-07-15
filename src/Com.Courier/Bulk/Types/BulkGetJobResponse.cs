using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record BulkGetJobResponse
{
    [JsonPropertyName("job")]
    public required JobDetails Job { get; init; }
}
