using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ProfileGetParameters
{
    [JsonPropertyName("recipientId")]
    public required string RecipientId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
