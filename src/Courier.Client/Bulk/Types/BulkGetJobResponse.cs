using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record BulkGetJobResponse
{
    [JsonPropertyName("job")]
    public required JobDetails Job { get; init; }
}
