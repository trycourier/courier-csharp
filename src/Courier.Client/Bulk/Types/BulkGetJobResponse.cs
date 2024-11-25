using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkGetJobResponse
{
    [JsonPropertyName("job")]
    public required JobDetails Job { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
