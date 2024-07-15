using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SubmissionChecksReplaceResponse
{
    [JsonPropertyName("checks")]
    public IEnumerable<Check> Checks { get; init; } = new List<Check>();
}
