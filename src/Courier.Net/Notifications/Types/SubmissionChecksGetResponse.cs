using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record SubmissionChecksGetResponse
{
    [JsonPropertyName("checks")]
    public IEnumerable<Check> Checks { get; init; } = new List<Check>();
}
