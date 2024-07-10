using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;
using OneOf;

#nullable enable

namespace Courier.Net;

public record AudienceUpdateParams
{
    /// <summary>
    /// The name of the audience
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// A description of the audience
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("filter")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<SingleFilterConfig, NestedFilterConfig>>))]
    public OneOf<SingleFilterConfig, NestedFilterConfig>? Filter { get; init; }
}
