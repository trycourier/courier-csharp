using System.Text.Json.Serialization;

namespace Courier.Net;

public class Email
{
    [JsonPropertyName("footer")]
    public object Footer { get; init; }

    [JsonPropertyName("header")]
    public object Header { get; init; }
}
