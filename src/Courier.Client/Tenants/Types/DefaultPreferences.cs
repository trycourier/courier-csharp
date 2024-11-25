using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record DefaultPreferences
{
    [JsonPropertyName("items")]
    public IEnumerable<SubscriptionTopic>? Items { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
