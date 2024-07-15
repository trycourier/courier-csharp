using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubmissionChecksReplaceResponse
{
    [JsonPropertyName("checks")]
    public IEnumerable<Check> Checks { get; init; } = new List<Check>();
}
