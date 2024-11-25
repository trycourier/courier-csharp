using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkCreateJobParams
{
    [JsonPropertyName("message")]
    public required InboundBulkMessage Message { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
