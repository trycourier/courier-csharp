using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubmissionChecksReplaceParams
{
    [JsonPropertyName("checks")]
    public IEnumerable<BaseCheck> Checks { get; set; } = new List<BaseCheck>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
