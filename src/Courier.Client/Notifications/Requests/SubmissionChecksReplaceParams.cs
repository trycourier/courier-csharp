using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record SubmissionChecksReplaceParams
{
    [JsonPropertyName("checks")]
    public IEnumerable<BaseCheck> Checks { get; set; } = new List<BaseCheck>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
