using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record BrandSettings
{
    [JsonPropertyName("colors")]
    public BrandColors? Colors { get; set; }

    [JsonPropertyName("inapp")]
    public object? Inapp { get; set; }

    [JsonPropertyName("email")]
    public Email? Email { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
