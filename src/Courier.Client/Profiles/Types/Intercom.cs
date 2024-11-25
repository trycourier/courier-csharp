using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Intercom
{
    [JsonPropertyName("from")]
    public required string From { get; set; }

    [JsonPropertyName("to")]
    public required IntercomRecipient To { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
