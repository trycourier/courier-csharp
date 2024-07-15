using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record AddSubscribersToList
{
    [JsonPropertyName("recipients")]
    public IEnumerable<PutSubscriptionsRecipient> Recipients { get; init; } =
        new List<PutSubscriptionsRecipient>();
}
