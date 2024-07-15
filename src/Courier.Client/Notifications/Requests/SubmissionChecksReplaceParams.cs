using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record SubmissionChecksReplaceParams
{
    [JsonPropertyName("checks")]
    public IEnumerable<BaseCheck> Checks { get; init; } = new List<BaseCheck>();
}
