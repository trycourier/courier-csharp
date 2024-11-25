using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkGetJobParams
{
    [JsonPropertyName("jobId")]
    public required string JobId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
