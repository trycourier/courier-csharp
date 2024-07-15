using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record BaseFilterConfig
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ComparisonOperator, LogicalOperator>>))]
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
