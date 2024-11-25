using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationContentHierarchy
{
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    [JsonPropertyName("children")]
    public string? Children { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
