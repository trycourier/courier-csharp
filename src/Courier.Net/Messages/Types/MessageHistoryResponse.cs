using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class MessageHistoryResponse
{
    [JsonPropertyName("results")]
    public List<MessageDetails> Results { get; init; }
}
