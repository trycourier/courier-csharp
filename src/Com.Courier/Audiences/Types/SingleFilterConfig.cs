using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;
using OneOf;

#nullable enable

namespace Com.Courier;

public record SingleFilterConfig
{
    /// <summary>
    /// The value to use for filtering
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; init; }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; init; }

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    [JsonPropertyName("operator")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<ComparisonOperator, LogicalOperator>>))]
    public required OneOf<ComparisonOperator, LogicalOperator> Operator { get; init; }
}
