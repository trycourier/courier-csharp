using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

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
