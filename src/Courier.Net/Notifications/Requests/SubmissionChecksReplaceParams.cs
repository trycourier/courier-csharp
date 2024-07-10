using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record SubmissionChecksReplaceParams
{
    [JsonPropertyName("checks")]
    public IEnumerable<BaseCheck> Checks { get; init; } = new List<BaseCheck>();
}
