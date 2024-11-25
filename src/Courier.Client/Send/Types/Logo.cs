using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Logo
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}