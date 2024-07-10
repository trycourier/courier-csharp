using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record ListMessagesResponse
{
    /// <summary>
    /// Paging information for the result set.
    /// </summary>
    [JsonPropertyName("paging")]
    public required Paging Paging { get; init; }

    /// <summary>
    /// An array of messages with their details.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<MessageDetails> Results { get; init; } = new List<MessageDetails>();
}
