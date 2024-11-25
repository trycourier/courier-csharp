using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Rule
{
    [JsonPropertyName("start")]
    public string? Start { get; set; }

    [JsonPropertyName("until")]
    public required string Until { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
