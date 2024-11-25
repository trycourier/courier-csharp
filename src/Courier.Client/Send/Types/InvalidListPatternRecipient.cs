using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record InvalidListPatternRecipient
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("list_id")]
    public required string ListId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
