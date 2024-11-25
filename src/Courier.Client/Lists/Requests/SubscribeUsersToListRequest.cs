using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record SubscribeUsersToListRequest
{
    [JsonPropertyName("recipients")]
    public IEnumerable<PutSubscriptionsRecipient> Recipients { get; set; } =
        new List<PutSubscriptionsRecipient>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
