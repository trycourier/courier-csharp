using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ReplaceProfileRequest
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object?> Profile { get; set; } = new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
