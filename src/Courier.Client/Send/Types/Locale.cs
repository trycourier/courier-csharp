using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record Locale
{
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
