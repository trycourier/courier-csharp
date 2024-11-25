using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record PagerdutyRecipient
{
    [JsonPropertyName("pagerduty")]
    public required Pagerduty Pagerduty { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
