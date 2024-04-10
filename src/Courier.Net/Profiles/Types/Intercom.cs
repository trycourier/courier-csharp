using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class Intercom
{
    [JsonPropertyName("from")]
    public string From { get; init; }

    [JsonPropertyName("to")]
    public IntercomRecipient To { get; init; }
}
