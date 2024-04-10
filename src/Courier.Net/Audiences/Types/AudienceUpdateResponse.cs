using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class AudienceUpdateResponse
{
    [JsonPropertyName("audience")]
    public Audience Audience { get; init; }
}
