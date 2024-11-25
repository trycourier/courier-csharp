using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListMessagesResponse
{
    /// <summary>
    /// Paging information for the result set.
    /// </summary>
    [JsonPropertyName("paging")]
    public required Paging Paging { get; set; }

    /// <summary>
    /// An array of messages with their details.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<MessageDetails> Results { get; set; } = new List<MessageDetails>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
