using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record NestedFilterConfig
{
    [JsonPropertyName("rules")]
    public IEnumerable<OneOf<SingleFilterConfig, NestedFilterConfig>> Rules { get; set; } =
        new List<OneOf<SingleFilterConfig, NestedFilterConfig>>();

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
