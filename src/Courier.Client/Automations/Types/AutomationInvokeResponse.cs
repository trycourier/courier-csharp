using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AutomationInvokeResponse
{
    [JsonPropertyName("runId")]
    public required string RunId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
