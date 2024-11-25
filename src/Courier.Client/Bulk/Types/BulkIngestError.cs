using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BulkIngestError
{
    [JsonPropertyName("user")]
    public required object User { get; set; }

    [JsonPropertyName("error")]
    public required object Error { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
