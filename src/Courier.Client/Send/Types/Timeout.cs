using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Timeout
{
    [JsonPropertyName("provider")]
    public Dictionary<string, int>? Provider { get; set; }

    [JsonPropertyName("channel")]
    public Dictionary<string, int>? Channel { get; set; }

    [JsonPropertyName("message")]
    public int? Message { get; set; }

    [JsonPropertyName("escalation")]
    public int? Escalation { get; set; }

    [JsonPropertyName("criteria")]
    public Criteria? Criteria { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
