using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record AddSubscribersToList
{
    [JsonPropertyName("recipients")]
    public IEnumerable<PutSubscriptionsRecipient> Recipients { get; init; } =
        new List<PutSubscriptionsRecipient>();
}
