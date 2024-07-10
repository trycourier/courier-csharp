using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record BulkGetJobResponse
{
    [JsonPropertyName("job")]
    public required JobDetails Job { get; init; }
}
