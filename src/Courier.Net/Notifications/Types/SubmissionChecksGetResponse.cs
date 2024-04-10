using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class SubmissionChecksGetResponse
{
    [JsonPropertyName("checks")]
    public List<Check> Checks { get; init; }
}
