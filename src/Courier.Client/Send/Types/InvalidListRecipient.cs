using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record InvalidListRecipient
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("list_pattern")]
    public required string ListPattern { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
