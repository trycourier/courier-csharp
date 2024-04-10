using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class ListMessagesResponse
{
    /// <summary>
    /// Paging information for the result set.
    /// </summary>
    [JsonPropertyName("paging")]
    public Paging Paging { get; init; }

    /// <summary>
    /// An array of messages with their details.
    /// </summary>
    [JsonPropertyName("results")]
    public List<MessageDetails> Results { get; init; }
}
