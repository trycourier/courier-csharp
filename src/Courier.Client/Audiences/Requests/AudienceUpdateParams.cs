using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record AudienceUpdateParams
{
    /// <summary>
    /// The name of the audience
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of the audience
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("filter")]
    public OneOf<SingleFilterConfig, NestedFilterConfig>? Filter { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
