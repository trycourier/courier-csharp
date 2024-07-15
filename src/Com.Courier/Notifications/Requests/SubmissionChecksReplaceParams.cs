using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record SubmissionChecksReplaceParams
{
    [JsonPropertyName("checks")]
    public IEnumerable<BaseCheck> Checks { get; init; } = new List<BaseCheck>();
}
