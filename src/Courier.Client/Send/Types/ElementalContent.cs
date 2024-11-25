using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ElementalContent
{
    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("brand")]
    public object? Brand { get; set; }

    [JsonPropertyName("elements")]
    public IEnumerable<object> Elements { get; set; } = new List<object>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
