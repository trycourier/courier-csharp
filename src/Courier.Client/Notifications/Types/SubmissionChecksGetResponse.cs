using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubmissionChecksGetResponse
{
    [JsonPropertyName("checks")]
    public IEnumerable<Check> Checks { get; set; } = new List<Check>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
